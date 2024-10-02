using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchRot : MonoBehaviour
{
    public float rotationspeed;
    void Update()
    {
        transform.Rotate(transform.right * Time.deltaTime * rotationspeed);
    }
}
