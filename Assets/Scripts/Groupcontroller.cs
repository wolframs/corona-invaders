using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Groupcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform transform;
    public float speed = 2f;
    public float downwardTime = 1f;
    public float gameoverYaxis = -3.5f;
    public float rightBorder = 5;
    public float leftBorder = -5;
    private float timestamp;
    private bool moveright = false;
    private bool moveleft = false;
    private bool movedown = false;

    // Start is called before the first frame update
    void Start()
    {
        increaseRSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        checkPos();
        checkIfAllChildrenAreGone();
    }

    void move()
    {
        // Der Controller checkt in welche Richtung die Bewegung stattfinden muss, hier wird zur Bestimmung eine Kombination aus Zeit und Position verwendet
        if (moveleft && movedown && timestamp <= Time.time)
        {
            increaseRSpeed();
        }

        if (moveright && movedown && timestamp <= Time.time)
        {
            increaseLSpeed();
        }

        if (moveleft && transform.position.x < leftBorder || moveright && transform.position.x > rightBorder)
        {
            if ((transform.position.x > rightBorder || transform.position.x < leftBorder) && !movedown)
            {
                increaseDSpeed();
            }
        }
    }

    void increaseRSpeed()
    {
        // Geschwindikeit nach Rechts überschreibt aktuelle Geschw.
        moveleft = false;
        movedown = false;
        print("rechts");
        rb.velocity = new Vector2(0f, 0f);
        rb.velocity = speed * transform.right;
        moveright = true;
    }
    void increaseLSpeed()
    {
        // Geschwindikeit nach Links überschreibt aktuelle Geschw.
        moveright = false;
        movedown = false;
        print("links");
        rb.velocity = new Vector2(0f, 0f);
        rb.velocity = (-speed) * transform.right;
        moveleft = true;
    }

    void increaseDSpeed()
    {
        // Geschwindikeit nach Unten überschreibt aktuelle Geschw.
        print("runter");
        timestamp = Time.time + downwardTime;
        print(timestamp);
        rb.velocity = new Vector2(0f, 0f);
        rb.velocity = (-speed) * transform.up;
        movedown = true;
    }

    void checkPos()
    {
        if (transform.position.y < gameoverYaxis)
        {
            // WSI 07.05.20
            //SceneManager.LoadScene("Title");
            GameObject.Find("Game General Script").GetComponent<GameGeneral>().EndGame();
        }
    }

    void checkIfAllChildrenAreGone()
    {
        // Hier wird überprüft ob die Gruppe noch Gegner enthält. Wenn nicht wird die Gruppe gelöscht.
        print(transform.name + ":" + transform.childCount);
        if(transform.childCount == 0)
        {
            GameObject gameObject = transform.gameObject;
            Destroy(gameObject);
            print("gameObject wurde zerstört");
        }
    }
}
