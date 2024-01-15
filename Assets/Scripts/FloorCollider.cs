using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public Movement jump;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            jump.onFloor = true;

            Vector2 newPosition = transform.position;
            newPosition.y = collision.gameObject.transform.position.y;
            transform.position = newPosition;

            jump.rb.velocity = new Vector2(0f, jump.rb.velocity.y);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            jump.onFloor = false;
        }
    }
}
