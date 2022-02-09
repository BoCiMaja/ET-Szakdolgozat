using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : Spawner
{
    [SerializeField]
    [Range(0.2f, 8.00f)]
    public float density = 0.65f;

    private float expectedDistance;
    private GameObject previousCloud;
    private Texture2D nextImage;


    private void Start()
    {
        spawnedObjects = new Queue<GameObject>();
        expectedDistance = 0;
        InitializeCloudsInScreen();
        InitializeDespawnPosition();
    }

    private void InitializeDespawnPosition()
    {
        float cameraSize = Camera.main.orthographicSize * Camera.main.aspect;
        float cameraMinXPosition = Camera.main.GetComponent<CameraMovement>().minX;
        float cameraMinX = cameraMinXPosition - cameraSize;

        float maxImageWidth = spawnImages[0].width;
        foreach (Texture2D image in spawnImages)
        {
            if (maxImageWidth < image.width) maxImageWidth = image.width;
        }

        despawnMaxPositionX = cameraMinX - maxImageWidth * 0.75f / pixelsPerUnit;

        //Debug.Log(despawnMaxPositionX);
    }

    private void Update()
    {
        float distance = transform.position.x - previousCloud.transform.position.x;

        if (distance >= expectedDistance)
        {
            SpawnCloud(transform.position, nextImage);
        }

        DespawnIfOutOfPlaySpace();
    }

    private void InitializeCloudsInScreen()
    {
        nextImage = spawnImages[Random.Range(0, spawnImages.Length)];
        float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Vector3 spawnPosition = new Vector3(-cameraHalfWidth, transform.position.y, transform.position.z);

        while (spawnPosition.x <= transform.position.x)
        {
            SpawnCloud(spawnPosition, nextImage);
            spawnPosition.x += expectedDistance;
            //spawnPosition.x += nextImage.width / pixelsPerUnit * density;
        }
    }

    void SpawnCloud(Vector3 position, Texture2D textureToSpawn)
    {
        GameObject cloud = SpawnObject(position, textureToSpawn);
        (spawnedObjects as Queue<GameObject>).Enqueue(cloud);
        previousCloud = cloud;

        SetTheNewTextureImage();

        CalculateExpectedDistance();
    }

    private void SetTheNewTextureImage()
    {
        Texture2D tempImage;
        do
        {
            tempImage = spawnImages[Random.Range(0, spawnImages.Length)];
        }
        while (tempImage == nextImage);
        nextImage = tempImage;
    }

    private void CalculateExpectedDistance()
    {
        float previousImageSize = previousCloud.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        expectedDistance = (previousImageSize / 2 + nextImage.width / pixelsPerUnit / 2) * density;
    }

    private void DespawnIfOutOfPlaySpace()
    {
        if ((spawnedObjects as Queue<GameObject>).Peek().transform.position.x < despawnMaxPositionX)
        {
            GameObject objectToDestroy = (spawnedObjects as Queue<GameObject>).Dequeue();
            Object.Destroy(objectToDestroy);
        }
    }
}
