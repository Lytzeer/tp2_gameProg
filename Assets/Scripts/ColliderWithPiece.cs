using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWithPiece : MonoBehaviour
{
    public CreateObstacle obstacle;
    public CreatePiece piece;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piece")
        {
            obstacle.score++;
            // piece.piecesToRemove.Add(collision.gameObject);
            // Destroy(collision.gameObject);
            piece.pieces.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
