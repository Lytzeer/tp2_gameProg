using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePiece : MonoBehaviour
{
    public GameObject piece;
    public bool canCreate = true;
    public List<GameObject> pieces = new List<GameObject>();
    public List<GameObject> piecesToRemove = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<GameObject>();
        piecesToRemove = new List<GameObject>();
        StartCoroutine(SpawnPiece());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject piece in pieces)
        {
            if (piece.transform.position.x < -10.5f)
            {
                piecesToRemove.Add(piece);
                Destroy(piece);
            }
        }
        foreach (GameObject piece in piecesToRemove)
        {
            pieces.Remove(piece);
        }
    }

    IEnumerator SpawnPiece()
    {
        while (canCreate)
        {
            yield return new WaitForSeconds(0.25f);
            int randomNumber = Random.Range(1, 15);
            int randomNumberCheck = Random.Range(1, 7);
            if (randomNumber==randomNumberCheck)
            {
                GameObject newPiece = Instantiate(piece);
                newPiece.transform.position = new Vector2(10f, -4.08f);
                newPiece.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
                pieces.Add(newPiece);
            }

        }
    }
}
