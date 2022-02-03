using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [Header("Camera")]
    public float cameraSize = -1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraMovement cm = Camera.main.GetComponent<CameraMovement>();
            cm.SetActualCameraDatas(this);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        CameraMovement cm = Camera.main.GetComponent<CameraMovement>();
    //        cm.SetActualCameraDatas();
    //    }
    //}
}
