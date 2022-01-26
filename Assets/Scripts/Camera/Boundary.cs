using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [Header("Camera")]
    public float cameraSize = -1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Boundary");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraMovement cm = Camera.main.GetComponent<CameraMovement>();
            cm.SetActualCameraDatas();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraMovement cm = Camera.main.GetComponent<CameraMovement>();
            cm.SetActualCameraDatas();
        }
    }
}
