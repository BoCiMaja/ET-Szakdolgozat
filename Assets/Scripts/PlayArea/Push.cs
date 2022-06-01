using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Push : MonoBehaviour
{
    public float pushLength = 10f;
    public float speed;

    Vector3 pushDirection;
    Vector3 force;
    Vector3 targetPosition;

    GameObject objectToPush;

    float gravityscale;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        pushDirection = new Vector3(0, 1, 0);
        objectToPush = null;
        force = pushDirection * pushLength;
        //CalculatePushDirection(ref pushDirection);
    }


    private void Update()
    {
        if (objectToPush != null)
            PushObject();
    }

    private void PushObject()
    {
        //Vector3 position = Vector3.Lerp(objectToPush.transform.position, targetPosition, speed);
        //Vector3 position = Vector3.SmoothDamp(objectToPush.transform.position, targetPosition, ref velocity, speed);
        Vector3 position = Vector3.MoveTowards(objectToPush.transform.position, targetPosition, speed);

        Vector2 velocity = objectToPush.GetComponent<Rigidbody2D>().velocity;
        velocity.y = Mathf.Clamp(velocity.y, 0, position.y - objectToPush.transform.position.y);
        objectToPush.GetComponent<Rigidbody2D>().velocity = velocity;

        objectToPush.transform.position = position;

        if (targetPosition.y - 5 < position.y)
        {
            //objectToPush.GetComponent<Rigidbody2D>().gravityScale = gravityscale;
            objectToPush = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            setPushObject(collision.gameObject);
        }
    }

    //private void CalculatePushDirection(ref Vector3 pushDirection)
    //{
    //    Debug.LogError("Calculate");
    //}

    private void setPushObject(GameObject character)
    {
        //gravityscale = character.GetComponent<Rigidbody2D>().gravityScale;
        //character.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        objectToPush = character;
        targetPosition = new Vector3(character.transform.position.x, force.y, character.transform.position.z);
    }
}
