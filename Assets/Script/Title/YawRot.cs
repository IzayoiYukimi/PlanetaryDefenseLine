using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawRot : MonoBehaviour
{
    public float rotationspeed;
    void Update()
    {
        transform.Rotate(transform.up * Time.deltaTime * rotationspeed);
    }
}
