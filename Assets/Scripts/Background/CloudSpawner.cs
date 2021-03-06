using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : Spawner
{
    [Header("Spawn Settings")]
    [SerializeField]
    [Range(0.2f, 8.00f)]
    public float density = 0.65f;

    [Header("Cloud Settings")]
    [Range(1, 18)]
    public float verticalMovementIntensity = 12;

    [Header("Destroy Settings")]
    public Transform despawnTransform;

    //Private variables
    private float expectedDistance;
    private GameObject previousCloud;
    private Texture2D nextImage;

    private float distance = 0;

    private void Start()
    {
        if (layer == null)
            Debug.LogError("The layer cannot be null!");

        ScrollElements scrollComponent = layer.GetComponent<ScrollElements>();
        
        spawnedObjects = new Queue<GameObject>();
        expectedDistance = 0;
        InitializeCloudsInScreen();

        if (scrollComponent != null)
            scrollComponent.SetChildrenElements(spawnedObjects as Queue<GameObject>);
        else
            Debug.LogError("The layer must be contains a ScrollElements script!");
    }

    private void Update()
    {
        distance = transform.position.x - previousCloud.transform.position.x;

        if (distance >= expectedDistance)
        {
            SpawnCloud(transform.position, nextImage);
        }

        DespawnIfOutOfPlaySpace();
    }

    private void InitializeCloudsInScreen()
    {
        nextImage = spawnImages[Random.Range(0, spawnImages.Length)];
        Vector3 spawnPosition = new Vector3(despawnTransform.position.x, transform.position.y, transform.position.z);

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

        cloud.AddComponent<VerticalMovement>().intensity = verticalMovementIntensity;

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
        if ((spawnedObjects as Queue<GameObject>).Peek().transform.position.x < despawnTransform.position.x)
            Despawn();
    }

    private void Despawn()
    {
        GameObject objectToDestroy = (spawnedObjects as Queue<GameObject>).Dequeue();
        Destroy(objectToDestroy);
    }
}
