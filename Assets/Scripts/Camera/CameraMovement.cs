using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public GameObject character;

    [Range(0, 0.05f)]
    public float borderSize = 0.03f;

    public float minX;
    private float maxX;

    private void Start()
    {
        SetMinAndMaxXValues();
    }

    private void SetMinAndMaxXValues()
    {
        float cameraSize = Camera.main.orthographicSize * Camera.main.aspect;
        float border = backgroundRenderer.bounds.size.x * borderSize;

        float backgroundMinX = backgroundRenderer.transform.position.x - backgroundRenderer.bounds.size.x / 2;
        minX = backgroundMinX + (cameraSize + border);

        float backgroundMaxX = backgroundRenderer.transform.position.x + backgroundRenderer.bounds.size.x / 2;
        maxX = backgroundMaxX - (cameraSize + border);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = character.transform.position;
        
        transform.position = Clamp(targetPosition);
    }

    private Vector3 Clamp(Vector3 targetPosition)
    {
        Vector3 position = new Vector2();

        float x = Mathf.Clamp(targetPosition.x, minX, maxX);
        position.x = x;

        //TODO: y
        position.y = transform.position.y;

        position.z = transform.position.z;

        return position;
    }
}
