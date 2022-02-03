using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public GameObject camera;
    private Vector3 startPos;
    public Vector2 parallaxEffect;
    public Vector2 parallaxEffectVector;

    private Vector3 previousCamPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        previousCamPos = camera.transform.position;
    }

    void FixedUpdate()
    {
        //float dist = (camera.transform.position.x * parallaxEffect);

        Vector3 displacement = (camera.transform.position - previousCamPos) * parallaxEffect;

        //transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        transform.position = new Vector3(transform.position.x + displacement.x,
                                         transform.position.y + displacement.y,
                                         transform.position.z);

        previousCamPos = camera.transform.position;
    }
}
