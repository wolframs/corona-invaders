using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControlSpace : MonoBehaviour {

    public float faktor = 10;
    public float maxPosX = 8.2f;
    public float minPosX = -8.2f;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        control();
    }

    void control()
    {
        // Hier wird bei jedem Frame entsprechend dem Keyboardinput die neue Position berechnet
        float xInput = Input.GetAxis("Horizontal");
        float newposition = transform.position.x + xInput * Time.deltaTime * faktor;
        if (newposition > maxPosX)
        {
            newposition = maxPosX;
        }
        if (newposition < minPosX)
        {
            newposition = minPosX;
        }
        transform.position = new Vector3(newposition, transform.position.y, 0);
    }



    void init()
    {
        // Hier wird initial die Position des Spielers gesetzt
        float newposition = transform.position.y - 4;
        transform.position = new Vector3(0, newposition, 0);
    }
}
