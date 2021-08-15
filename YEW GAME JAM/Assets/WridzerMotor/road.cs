using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position += new Vector3(0, 20, 0);
        }
        transform.position += new Vector3(0, -0.02f, 0);
    }
}
