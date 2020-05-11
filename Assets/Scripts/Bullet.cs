using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 20f;
    public Rigidbody2D bulletbody;

    // Start is called before the first frame update
    void Start()
    {
        // Initial wird der Kugel eine Geschwindigkeit zugewiesen
        bulletbody.velocity = transform.up * velocity;
    }

    void OnTriggerEnter2D()
    {
        // Bei Kollision wird das getroffene Objekt zerstört
        Destroy(gameObject);
    }
}
