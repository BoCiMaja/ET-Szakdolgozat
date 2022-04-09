using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCameraZooming : MonoBehaviour
{
    [Header("Zoom")]
    Camera cam;
    public float defaultSize = 5.0f;
    bool zooming;
    private float camSize;
    private float zoomVelocity = 0.0f;
    public float zoomSpeed = 0.6f;

    private CameraColliderBox colliderComponent;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        colliderComponent = GetComponent<CameraColliderBox>();
    }

    private void Start()
    {
        zooming = false;
    }

    private void LateUpdate()
    {
        if (zooming)
            Zoom();
    }

    private void Zoom()
    {
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, camSize, ref zoomVelocity, zoomSpeed);

        if (camSize - 0.0001 < cam.orthographicSize && camSize + 0.0001 > cam.orthographicSize)
        {
            cam.orthographicSize = camSize;
            zooming = false;
        }

        colliderComponent.CalculateCameraColliderBox();
    }

    public void SetCameraSize(float camSize)
    {
        this.camSize = -1 == camSize || camSize == 0 ? defaultSize : camSize;
        if (this.camSize != cam.orthographicSize)
            zooming = true;
    }

    public void SetCameraSize(float[] camSizes)
    {
        float camSize = 0;

        if (camSizes.Length <= 0)
            SetCameraSize(defaultSize);
        else
        {
            foreach (float size in camSizes)
            {
                camSize += size == -1 || size == 0 ? defaultSize : size;
            }
            SetCameraSize(Mathf.Ceil(camSize / camSizes.Length));
        }
    }
}
