using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportenMetSean : MonoBehaviour
{
    public GameObject handLeft;
    public GameObject handRight;
    public GameObject weights;
    private bool shouldPressA;
    public float weightY;
    private bool done;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && shouldPressA)
        {
            Push();
            shouldPressA = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && !shouldPressA)
        {
            Push();
            shouldPressA = true;
        }
        Debug.Log(weights.GetComponent<RectTransform>().anchoredPosition.y);
        if (weights.GetComponent<RectTransform>().anchoredPosition.y > 417 && !done)
        {
            done = true;
            FindObjectOfType<GameMaster>().Win();
        }
    }

    private void Push()
    {
        handLeft.transform.position += new Vector3(0, weightY, 0);
        handRight.transform.position += new Vector3(0, weightY, 0);
        weights.transform.position += new Vector3(0, weightY, 0);
    }
}
