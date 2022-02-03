using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderBox : MonoBehaviour
{
    private Camera camera;
    private BoxCollider2D cameraCollider;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        cameraCollider = GetComponent<BoxCollider2D>();
        if (cameraCollider == null)
            cameraCollider = gameObject.AddComponent<BoxCollider2D>();
        CalculateCameraColliderBox();
    }

    public void CalculateCameraColliderBox()
    {
        float sizeY = camera.orthographicSize * 2;
        float ratio = (float)Screen.width / (float)Screen.height;
        float sizeX = sizeY * ratio;
        cameraCollider.size = new Vector2(sizeX, sizeY);
    }
}
