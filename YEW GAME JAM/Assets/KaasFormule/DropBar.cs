using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBar : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            FindObjectOfType<KaasformuleManager>().keysPressed++;
            Destroy(gameObject);
        }
    }
}
