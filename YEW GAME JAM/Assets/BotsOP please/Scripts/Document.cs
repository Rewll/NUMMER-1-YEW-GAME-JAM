using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Document : MonoBehaviour, IPointerDownHandler
{
    public bool isCheese;
    [SerializeField] private GameObject botsopApproved;
    private int endDestination;
    private RectTransform transform;
    private bool shouldGoDown;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (isCheese)
        {
            gameManager.amoutOfCheese++;
        }
        endDestination = Random.Range(-280, -860);
        transform = GetComponent<RectTransform>();
    }

    private void StartGoingDown()
    {
        shouldGoDown = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        Invoke("StartGoingDown", 0.3f);
        Destroy(gameObject, 2);
        GameObject stamp;
        stamp = Instantiate(botsopApproved, Input.mousePosition, Quaternion.Euler(40,0,0), gameObject.transform);
        stamp.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, Random.Range(-10,10)));
        if (!isCheese)
        {
            gameManager.notCheeseDocumentCleared++;
        }
        else
        {
            gameManager.amountOfCheeseCleared++;
        }
    }
    
    private void Update()
    {
        if(shouldGoDown || transform.anchoredPosition.y > endDestination)
            transform.anchoredPosition += new Vector2(0, -2);
    }
}
