using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWithObj : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
