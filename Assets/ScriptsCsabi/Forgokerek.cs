using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forgokerek : MonoBehaviour
{ 
    public float speed = 0f;



    void Update()
    {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);

    }
}
