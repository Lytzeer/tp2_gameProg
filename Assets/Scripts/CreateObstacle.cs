using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject obstacle;
    public bool canCreate = true;
    public float YPosition= -3.1f;
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
            float speed = -5f;
            if (score%10==0 && score!=0)
            {
                speed -= 1f;
            }
            float randomTime = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(randomTime);

            int randomNumber = Random.Range(1, 3);
            int randomNumberCheck = Random.Range(1, 3);
            if (randomNumber==randomNumberCheck)
            {
                for (int i = 0; i < randomNumber; i++)
                {
                    yield return new WaitForSeconds(0.25f);
                    GameObject newObstacle = Instantiate(obstacle);
                    newObstacle.transform.position = new Vector2(10f, YPosition-1.0f);
                    newObstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
                    obstacles.Add(newObstacle);
                }
            }else{
                float scale = Random.Range(0.8f, 1.5f);
                GameObject newObstacle = Instantiate(obstacle);
                newObstacle.transform.position = new Vector2(10f, YPosition-scale);
                newObstacle.transform.localScale = new Vector2(scale, scale);
                newObstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
                obstacles.Add(newObstacle);
            }
        }
    }
}
