using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invBullet : MonoBehaviour
{
    public float velocity = 20f;
    public Rigidbody2D bulletbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletbody.velocity = transform.up * velocity;
        print(transform.up * velocity);
    }

    void OnTriggerEnter2D()
    {
        GameObject.Find("Game General Script").GetComponent<GameGeneral>().EndGame();
    }
}
