using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBar2 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            FindObjectOfType<KaasformuleManager>().keysPressed++;
            Destroy(gameObject);
        }
    }
}
