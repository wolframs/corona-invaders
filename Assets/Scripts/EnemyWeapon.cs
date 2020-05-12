using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    // Dieser Skript wird für jeden Gegner verwendet

    public float cooldowntime = 1f;
    public GameObject bulletpref;
    public Transform firepoint;
    float weaponcooldowntimestamp;
    // WSI 12.05.20:
    private AudioManager AudioMan;
    private GameObject scoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        init();
        // WSI 12.05.20:
        scoreSystem = GameObject.Find("Score System");
        AudioMan = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        control();
    }

    void control()
    {
        // Nur wenn der letzte Timestamp überschritten ist und die Zufallszahl 6 ist wird geschossen.
        // Die Zufallszahl wird für jedes Frame und jeden Gegner ermittelt
        if (weaponcooldowntimestamp <= Time.time && Random.Range(1,3000) == 6)
        {
            shoot();
        }
    }

    void init()
    {
        // Der Cooldowntimestamp wird initial bei Spielstart gesetzt
        weaponcooldowntimestamp = Time.time;
    }

    void shoot()
    {
        // Eine Kugel wird erzeugt und der Timestamp erneuert (aktuelle Zeit + Cooldownzeit)
        weaponcooldowntimestamp = Time.time + cooldowntime;
        Instantiate(bulletpref, firepoint.position, firepoint.rotation);
        print("Schuss!!!");

        // WSI 12.05.20:
        // Score ++ für jeden "überlebten" Schuss
        if (scoreSystem != null)
            scoreSystem.GetComponent<IngameScore>().ScoreEnemyShot();
        // Sound:
        AudioMan.Play("EnemyPew");
    }
}
