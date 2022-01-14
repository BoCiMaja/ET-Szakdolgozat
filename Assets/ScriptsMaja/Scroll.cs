using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    public float speed = 0.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = transform.position.x - Time.deltaTime * speed;

        transform.position = new Vector3( dist, transform.position.y, transform.position.z);
    }
}
