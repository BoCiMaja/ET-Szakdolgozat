using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cloudLayer;

    private Texture2D nextImage;
    public float pixelsPerUnit = 100f;

    [Range(1, 18)]
    public float verticalMovementIntensity = 12;

    private GameObject previousCloud;

    private float expectedDistance;
    private float despawnMaxPositionX;

    [SerializeField]
    [Range(0.2f, 8.00f)]
    public float density = 0.65f;

    public Texture2D[] spawnImages;
    private Queue<GameObject> spawnedObjects;

    // Start is called before the first frame update
    void Start()
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

        Debug.Log(despawnMaxPositionX);
    }

    private void InitializeCloudsInScreen()
    {
        nextImage = spawnImages[Random.Range(0, spawnImages.Length)];
        float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Vector3 spawnPosition = new Vector3(-cameraHalfWidth, transform.position.y, transform.position.z);

        while (spawnPosition.x <= transform.position.x)
        {
            SpawnObject(spawnPosition, nextImage);
            spawnPosition.x += nextImage.width / pixelsPerUnit * density;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = transform.position.x - previousCloud.transform.position.x;

        if ( distance >= expectedDistance)
        {
            SpawnObject(transform.position, nextImage);
        }

        despawnIfOutOfPlaySpace();
    }

    private void despawnIfOutOfPlaySpace()
    {
        if(spawnedObjects.Peek().transform.position.x < despawnMaxPositionX)
        {
            GameObject objectToDestroy = spawnedObjects.Dequeue();
            Object.Destroy(objectToDestroy);
        }
    }

    void SpawnObject(Vector3 position, Texture2D spawnObject)
    {
        GameObject cloud = createCloudGameObject(position);
        spawnedObjects.Enqueue(cloud);
        previousCloud = cloud;

        GetTheNewTextureImage();

        CalculateExpectedDistance();
    }

    private GameObject createCloudGameObject(Vector3 position)
    {
        GameObject cloud = new GameObject(nextImage.name);
        cloud.transform.position = position;
        cloud.transform.SetParent(cloudLayer.transform);

        SpriteRenderer spriteRenderer = cloud.AddComponent<SpriteRenderer>() as SpriteRenderer;

        Sprite tempSprite = Sprite.Create(nextImage, new Rect(0, 0, nextImage.width, nextImage.height), new Vector2(0.5f, 0.5f), pixelsPerUnit);
        spriteRenderer.sprite = tempSprite;

        VerticalMovement component = cloud.AddComponent<VerticalMovement>();
        component.intensity = verticalMovementIntensity;

        return cloud;
    }

    private void GetTheNewTextureImage()
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
}
