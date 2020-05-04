using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Groupcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2f;
    public float downwardTime = 1f;
    public float gameoverYaxis = -3.5f;
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
    }

    void move()
    {
        if (moveleft && movedown && timestamp <= Time.time)
        {
            increaseRSpeed();
        }

        if (moveright && movedown && timestamp <= Time.time)
        {
            increaseLSpeed();
        }

        if (moveleft && transform.position.x < -5 || moveright && transform.position.x > 5)
        {
            if ((transform.position.x > 5 || transform.position.x < -5) && !movedown)
            {
                increaseDSpeed();
            }
        }
    }

    void increaseRSpeed()
    {
        moveleft = false;
        movedown = false;
        print("rechts");
        rb.velocity = new Vector2(0f, 0f);
        rb.velocity = speed * transform.right;
        moveright = true;
    }
    void increaseLSpeed()
    {

        moveright = false;
        movedown = false;
        print("links");
        rb.velocity = new Vector2(0f, 0f);
        rb.velocity = (-speed) * transform.right;
        moveleft = true;
    }

    void increaseDSpeed()
    {
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
            SceneManager.LoadScene("Title");
        }
    }
}
