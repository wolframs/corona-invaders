using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControlSpace : MonoBehaviour {

    public float faktor = 10;

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
        float xInput = Input.GetAxis("Horizontal");
        float newposition = transform.position.x + xInput * Time.deltaTime * faktor;
        if (newposition > 8.5f)
        {
            newposition = 8.5f;
        }
        if (newposition < -8.5f)
        {
            newposition = -8.5f;
        }
        transform.position = new Vector3(newposition, transform.position.y, 0);
    }

    void init()
    {
        float newposition = transform.position.y - 4;
        transform.position = new Vector3(0, newposition, 0);
    }
}
