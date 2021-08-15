using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += new Vector3(0, -0.1f, 0);
    }
}
