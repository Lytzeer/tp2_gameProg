using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject jumper;
    public float jumpForce = 10f;
    public bool onFloor = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && onFloor)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            StartCoroutine(RotateJumper(jumper, 1.0f));

        }
    }

    IEnumerator RotateJumper(GameObject target, float duration)
    {
        Quaternion startRotation = target.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, 180);

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            target.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }

        target.transform.rotation = endRotation;
    }
}
