using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    public float speed = 0.5f;

    protected float diffX = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        diffX = Time.deltaTime * speed;
        Scrolling();
    }

    protected virtual void Scrolling()
    {
        transform.position = new Vector3(transform.position.x - diffX, transform.position.y, transform.position.z);
    }
    
    private void ScrollElement()
    {
        transform.position = new Vector3(transform.position.x - diffX, transform.position.y, transform.position.z);
    }

    protected void ScrollElement(Transform goTransform)
    {
        goTransform.position = new Vector3(goTransform.position.x - diffX, goTransform.position.y, goTransform.position.z);
    }
}
