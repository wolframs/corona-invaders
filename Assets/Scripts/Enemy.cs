using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        EnemyScore();
        Destroy(gameObject);
    }

    // WSI 07.05.20:
    private void EnemyScore()
    {
        GameObject scoreSystem = GameObject.Find("Score System");
        if (scoreSystem != null)
            scoreSystem.GetComponent<IngameScore>().ScoreEnemyDestroyed();
    }
}
