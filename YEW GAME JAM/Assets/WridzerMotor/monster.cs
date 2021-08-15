using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    
    void Update()
    {
        transform.position += new Vector3(0, -0.01f, 0);
    }
}
