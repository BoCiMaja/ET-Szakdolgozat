using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [Header("Layer")]
    public GameObject layer;
    public string sortingLayer = "PlayArea";
    public float pixelsPerUnit = 100f;
    public Texture2D[] spawnImages;
    public int orderInLayer = 0;


    [Range(1, 18)]
    public float verticalMovementIntensity = 12;


    protected IEnumerable<GameObject> spawnedObjects;

    protected GameObject SpawnObject(Vector3 position, Texture2D texture)
    {
        GameObject spawnedObject = new GameObject(texture.name);
        spawnedObject.transform.position = position;
        spawnedObject.transform.SetParent(layer.transform);

        SpriteRenderer spriteRenderer = spawnedObject.AddComponent<SpriteRenderer>() as SpriteRenderer;

        spriteRenderer.sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit);

        spriteRenderer.sortingLayerName = sortingLayer;
        spriteRenderer.sortingOrder = orderInLayer;

        //TODO: biztos van szebb megoldas
        Shader shader = Shader.Find("Universal Render Pipeline/2D/Sprite-Lit-Default");
        spriteRenderer.material = new Material(shader);
        //

        VerticalMovement component = spawnedObject.AddComponent<VerticalMovement>();
        component.intensity = verticalMovementIntensity;

        return spawnedObject;
    }
}
