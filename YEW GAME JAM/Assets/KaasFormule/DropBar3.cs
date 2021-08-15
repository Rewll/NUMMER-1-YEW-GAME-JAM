using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBar3 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FindObjectOfType<KaasformuleManager>().keysPressed++;
            Destroy(gameObject);
        }
    }
}
