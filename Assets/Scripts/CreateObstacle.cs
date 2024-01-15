using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject obstacle;
    public bool canCreate = true;
    public float YPosition= -4.05f;
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
            yield return new WaitForSeconds(1f);
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = new Vector2(10f, YPosition); 
            newObstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
            obstacles.Add(newObstacle);
        }
    }
}
