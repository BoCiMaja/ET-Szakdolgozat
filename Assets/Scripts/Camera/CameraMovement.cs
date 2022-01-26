using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform character;
    private BoxCollider2D cameraBox;
    private GameObject[] boundaries;
    private Bounds[] allBounds;
    private Bounds targetBounds;

    public float speed = 10.0f;
    private float waitForSeconds = 0.5f;

    public float minX;
    private float maxX;

    private void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        FindBoundaries();
        SetTheActualLimit();
        //SetMinAndMaxXValues();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (waitForSeconds > 0)
            waitForSeconds -= Time.deltaTime;
        else
            FollowCharacter();
    }

    private void SetMinAndMaxXValues()
    {
        
    }

    private Vector3 velocity = Vector3.zero;

    private void FollowCharacter()
    {
        //TODO: calculate min and max values
        //TODO: Garbage Collector problem!!
        Vector3 targetPosition = new Vector3();

        if (cameraBox.size.x < targetBounds.size.x)
            targetPosition.x = Mathf.Clamp(character.position.x, targetBounds.min.x + cameraBox.size.x / 2, targetBounds.max.x - cameraBox.size.x / 2);
        else
            targetPosition.x = (targetBounds.min.x + targetBounds.max.x) / 2;

        if (cameraBox.size.y < targetBounds.size.y)
            targetPosition.y = Mathf.Clamp(character.position.y, targetBounds.min.y + cameraBox.size.y / 2, targetBounds.max.y - cameraBox.size.y / 2);
        else
            targetPosition.y = (targetBounds.min.y + targetBounds.max.y) / 2;

        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);
        //transform.position = Vector3.Lerp(transform.position, targetPosition, speed); //0.85
        //transform.position = Vector3.Slerp(transform.position, targetPosition, speed);
    }

    private void FindBoundaries()
    {
        boundaries = GameObject.FindGameObjectsWithTag("Boundary");
        allBounds = new Bounds[boundaries.Length];
        for (int i = 0; i < allBounds.Length; i++)
        {
            allBounds[i] = boundaries[i].gameObject.GetComponent<BoxCollider2D>().bounds;
        }
    }

    public void SetTheActualLimit()
    {
        for (int i = 0; i < allBounds.Length; i++)
        {
            if (character.position.x > allBounds[i].min.x &&
               character.position.x < allBounds[i].max.x &&
               character.position.y > allBounds[i].min.y &&
               character.position.y < allBounds[i].max.y)
            {
                targetBounds = allBounds[i];
                break;
            }
        }
    }   
    
    //private Vector3 Clamp(Vector3 targetPosition)
    //{
    //    Vector3 position = new Vector2();

    //    float x = Mathf.Clamp(targetPosition.x, minX, maxX);
    //    position.x = x;

    //    //TODO: y
    //    position.y = transform.position.y;

    //    position.z = transform.position.z;

    //    return position;
    //}
}
