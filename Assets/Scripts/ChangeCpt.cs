using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCpt : MonoBehaviour
{
    public Text compteur;
    public CreateObstacle createObstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        compteur.text = createObstacle.score.ToString();
    }
}
