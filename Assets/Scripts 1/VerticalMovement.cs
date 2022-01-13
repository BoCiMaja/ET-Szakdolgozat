using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    private float movementValue;
    private float density;

    [Range(1, 18)]
    public float intensity = 12;

    private float originalY;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer cloudRenderer = gameObject.GetComponent<SpriteRenderer>();
        movementValue = Random.Range(0, cloudRenderer.bounds.size.y / 3);
        density = Random.Range(-3.0f, 3.0f);
        if (Random.Range(0, 1.0f) > 0.5f)
            movementValue = -movementValue;
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //float y = (movementValue * Mathf.Sin(transform.position.x + density) + originalY);
        float y = (movementValue * Mathf.Sin(Time.realtimeSinceStartup / intensity + density) + originalY);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
