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
        // Initial wird der Kugel eine negative Geschwindigkeit zugewiesen (Dies ist der Skript für gegnerische Schüsse)
        bulletbody.velocity = transform.up * velocity;
        print(transform.up * velocity);
    }

    void OnTriggerEnter2D()
    {
        // Spiel wird beim Trigger beendet
        GameObject.Find("Game General Script").GetComponent<GameGeneral>().EndGame();
    }
}
