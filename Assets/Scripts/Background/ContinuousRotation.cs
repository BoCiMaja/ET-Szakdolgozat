using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotationSpeed = 0.5f;

    // Update is called once per frame

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed, Space.Self);
        
    }
}
