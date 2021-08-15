using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    private int currentLane = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
        {
            currentLane--;
            gameObject.transform.position += new Vector3(-2.85f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            currentLane++;
            gameObject.transform.position += new Vector3(2.85f, 0, 0);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            //lose
        }
    }

}
