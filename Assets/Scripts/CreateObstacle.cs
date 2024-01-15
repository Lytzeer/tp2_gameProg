using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject obstacle;
    public bool canCreate = true;
    public float YPosition= -4.08f;
    public int score = 0;
    public List<GameObject> obstacles = new List<GameObject>();
    public List<GameObject> obstaclesToRemove = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        obstacles= new List<GameObject>();
        obstaclesToRemove = new List<GameObject>();
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.x < -10.5f)
            {
                obstaclesToRemove.Add(obstacle);
                Destroy(obstacle);
                score++;
            }
        }
        foreach (GameObject obstacle in obstaclesToRemove)
        {
            obstacles.Remove(obstacle);
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (canCreate)
        {
            float randomTime = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(randomTime);

            int randomNumber = Random.Range(1, 4);
            int randomNumberCheck = Random.Range(1, 4);
            if (randomNumber==randomNumberCheck)
            {
                for (int i = 0; i < randomNumber; i++)
                {
                    yield return new WaitForSeconds(0.25f);
                    GameObject newObstacle = Instantiate(obstacle);
                    newObstacle.transform.position = new Vector2(10f, YPosition);
                    newObstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
                    obstacles.Add(newObstacle);
                }
            }else{
                GameObject newObstacle = Instantiate(obstacle);
                newObstacle.transform.position = new Vector2(10f, YPosition);
                newObstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
                obstacles.Add(newObstacle);
            }
        }
    }
}
