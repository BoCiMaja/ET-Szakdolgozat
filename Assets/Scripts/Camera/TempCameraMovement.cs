using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TempCameraMovement : MonoBehaviour
{
    public float minX;

    [Header("Follow")]
    public Transform character;
    public float speed = 0.3f;

    [Header("Follow Unbound")]
    public float offsetY;

    private Boundary[] boundaries;
    private Bounds targetBounds;
    private Vector3 targetPosition;
    private bool independentCamera;

    private Vector3 velocity = Vector3.zero;
    private float waitForSeconds = 0.5f;

    private BoxCollider2D cameraBox;
    private TempCameraZooming zoomComponent;

    private List<Boundary> intersectingBoundaries;

    private delegate void Follow();
    private Follow FollowCharacter;

    private void Awake()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        targetPosition = new Vector3(0, 0, 0);
        intersectingBoundaries = new List<Boundary>();
        zoomComponent = GetComponent<TempCameraZooming>();
        independentCamera = true;
        FollowCharacter = FollowCharacterFree;
    }

    private void Start()
    {
        if (!character)
            character = GameObject.FindGameObjectWithTag("Player").transform;
        FindBoundaries();
        SetActualCameraData();
    }

    private void LateUpdate()
    {
        if (waitForSeconds > 0)
            waitForSeconds -= Time.deltaTime;
        else
            FollowCharacter();
    }

    private void FollowCharacterInBounds()
    {
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

    private void FollowCharacterFree()
    {
        targetPosition = new Vector3(character.position.x, character.position.y + offsetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);
    }

    private void FindBoundaries()
    {
        boundaries = FindObjectsOfType<Boundary>();
    }

    private void SetActualCameraData()
    {
        foreach (Boundary boundary in boundaries)
        {
            Bounds bounds = boundary.GetComponent<BoxCollider2D>().bounds;
            if (character.position.x > bounds.min.x &&
                character.position.x < bounds.max.x &&
                character.position.y > bounds.min.y &&
                character.position.y < bounds.max.y)
            {
                intersectingBoundaries.Add(boundary);
            }
        
        }

        if (intersectingBoundaries.Count == 1)
        {
            BoundCameraToBoundary(intersectingBoundaries[0]);
        }
        else
        {
            ReleaseCamera();
        }

    }

    public void EnterBoundary(Boundary enteredBoundary)
    {
        if(boundaries.Contains(enteredBoundary) && !intersectingBoundaries.Contains(enteredBoundary))
        {
            intersectingBoundaries.Add(enteredBoundary);

            if (intersectingBoundaries.Count == 1)
            {
                BoundCameraToBoundary(enteredBoundary);
            }
            else
            {
                ReleaseCamera();
            }
        }
    }

    public void ExitBounday(Boundary exitBoundary)
    {
        if (boundaries.Contains(exitBoundary) && intersectingBoundaries.Contains(exitBoundary))
        {
            intersectingBoundaries.Remove(exitBoundary);

            if (intersectingBoundaries.Count == 1)
            {
                BoundCameraToBoundary(intersectingBoundaries[0]);
            }
            else
            {
                ReleaseCamera();
            }
        }
    }

    private void BoundCameraToBoundary()
    {
        if(intersectingBoundaries.Count > 0)
            BoundCameraToBoundary(intersectingBoundaries[0]);
    }

    private void BoundCameraToBoundary(Boundary boundary)
    {
        targetBounds = boundary.GetComponent<BoxCollider2D>().bounds;
        zoomComponent.SetCameraSize(boundary.cameraSize);
        FollowCharacter = FollowCharacterInBounds;
    }

    private void ReleaseCamera()
    {
        independentCamera = true;
        FollowCharacter = FollowCharacterFree;

        float[] camSizes = new float[intersectingBoundaries.Count];
        for (int i = 0; i < camSizes.Length; i++)
        {
            camSizes[i] = intersectingBoundaries[i].cameraSize;
        }
        zoomComponent.SetCameraSize(camSizes);
    }
}
