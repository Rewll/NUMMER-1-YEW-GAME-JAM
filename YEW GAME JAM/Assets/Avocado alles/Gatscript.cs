using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatscript : MonoBehaviour
{
    public GameObject avocado;
    public int levelInt = 0;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    [Space]
    public Transform pos2;
    public Transform pos3;
    private Vector2 velocity = Vector2.zero;
    public float dampSpeed;
    Vector3 holePos;

    private void Start()
    {
        checkLevelIndex();
        holePos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pit")
        {
            levelInt++;
            checkLevelIndex();
            collision.gameObject.transform.position = transform.position;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.SmoothDamp(transform.position, holePos, ref velocity, dampSpeed);
    }


    void checkLevelIndex()
    {
        if (levelInt == 1)
        {
            level1.SetActive(false);
            level2.SetActive(true);
            holePos = pos2.position;
        }
        if (levelInt == 2)
        {
            level2.SetActive(false);
            level3.SetActive(true);
            holePos = pos3.position;
        }
    }


}