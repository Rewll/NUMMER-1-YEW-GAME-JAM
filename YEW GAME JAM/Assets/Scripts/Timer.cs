using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int totalTime;
    public float timeTillStart;
    public TMP_Text timerText;
    public bool endTimerWin;
    private bool stopTimer;
    
    void Start()
    {
        timerText.text = totalTime.ToString();
        Invoke("UpdateTimer", timeTillStart);
    }

    private void UpdateTimer()
    {
        if (totalTime > 0 && !stopTimer)
        {
            totalTime--;
            timerText.text = totalTime.ToString();
            Invoke("UpdateTimer", 1);
            return;
        }
        if (!stopTimer && totalTime == 0)
        {
            Invoke("Lose", 1);
        }
        
    }

    private void Lose()
    {
        if (endTimerWin)
        {
            return;
        }
        //lose
    }

    public void StopTimer()
    {
        stopTimer = true;
    }
}
