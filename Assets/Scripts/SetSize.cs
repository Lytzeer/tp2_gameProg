using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSize : MonoBehaviour
{
    public float screenWidth;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        floor.transform.localScale = new Vector2(screenWidth, 3f);
    }
}
