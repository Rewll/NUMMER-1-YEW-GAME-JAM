using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaasformuleManager : MonoBehaviour
{
    public int keysPressed;
    private void Update()
    {
        if (keysPressed == 3)
        {
            FindObjectOfType<Timer>().StopTimer();
            Invoke("Win", 1);
            keysPressed++;
        }
    }

    private void Win()
    {
        
    }
}
