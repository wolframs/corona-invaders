using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldowntime = 1f;
    public GameObject bulletpref;
    public Transform firepoint;
    float weaponcooldowntimestamp;
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
        // Nur wenn der letzte Timestamp überschritten ist und der Space Button gedrückt ist wird geschossen
        if (weaponcooldowntimestamp <= Time.time && Input.GetKeyDown("space"))
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
        //audioManager.Play("");
    }

}
