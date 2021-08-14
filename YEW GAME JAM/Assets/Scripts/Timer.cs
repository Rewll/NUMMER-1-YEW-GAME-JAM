using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int totalTime;
    public float timeTillStart;
    public TMP_Text timerText;
    
    void Start()
    {
        timerText.text = totalTime.ToString();
        Invoke("UpdateTimer", timeTillStart);
    }

    private void UpdateTimer()
    {
        if (totalTime > 0)
        {
            totalTime--;
            timerText.text = totalTime.ToString();
            Invoke("UpdateTimer", 1);
        }                                                       
    }
}
