using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;

    public static GameMaster Instance { get { return _instance; } }

    public int gamesCompleted = 1;
    private int health = 3;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void Win()
    {
        gamesCompleted++;
        SceneManager.LoadScene(8);
        Invoke("LoadNextMinigame", 3);
    }
    
    public void Lose()
    {
        if (health == 1)
        {
            //Game over
        }
        gamesCompleted++;
        health--;
        SceneManager.LoadScene(7);
        Invoke("LoadNextMinigame", 3);
    }

    private void LoadNextMinigame()
    {
        SceneManager.LoadScene(gamesCompleted);
    }
}
