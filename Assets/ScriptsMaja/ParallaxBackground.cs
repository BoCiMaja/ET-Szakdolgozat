using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public GameObject camera;
    private float startPos;
    public float parallaxEffect;

    private Vector3 previousCamPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        previousCamPos = camera.transform.position;
    }

    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxEffect);

        Vector3 displacement = (camera.transform.position - previousCamPos) * parallaxEffect;

        //transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        transform.position = new Vector3(transform.position.x + displacement.x,
                                         transform.position.y + displacement.y,
                                         transform.position.z);

        previousCamPos = camera.transform.position;
    }
}
