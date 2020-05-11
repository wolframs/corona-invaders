using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountGroups : MonoBehaviour
{
    public new Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        childrencount();
    }

    void childrencount()
    {
        if(transform.childCount == 0)
        {
            GameObject.Find("Game General Script").GetComponent<GameGeneral>().EndGameFromSuccess();
        }
    }
}
