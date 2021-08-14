using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public int amoutOfCheese;
    public int amountOfCheeseCleared;
    public int notCheeseDocumentCleared;
    [SerializeField] private GameObject[] documents;
    [SerializeField] private GameObject canvas;
    private bool end;
    private void Start()
    {
        Invoke("StartGame", 1);
    }

    private void StartGame()
    {
        Invoke("SpawnDocument", 0.5f);
        Invoke("StartEnd", 10);
        Invoke("End", 12);
    }
    
    private void SpawnDocument()
    {
        if(!end)
            Invoke("SpawnDocument", 0.5f);
        
        Instantiate(documents[Random.Range(0, 10)], new Vector3(Random.Range(400,1600) * canvas.transform.localScale.x, 
            1500 * canvas.transform.localScale.x, 0), Quaternion.identity, canvas.transform);
    }

    private void StartEnd()
    {
        end = true;
    }

    private void End()
    {
        if (amoutOfCheese - amountOfCheeseCleared < 2 && notCheeseDocumentCleared < 2)
        {
            Debug.Log("Win");
            return;
        }
        Debug.Log("Lose");
    }
}
