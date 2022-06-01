using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Push : MonoBehaviour
{
    public float pushLength = 10f;

    Vector3 pushDirection;

    // Start is called before the first frame update
    void Start()
    {
        pushDirection = new Vector3(0, 1, 0);
        //CalculatePushDirection(ref pushDirection);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            PushObject(collision.gameObject);
        }
    }

    //private void CalculatePushDirection(ref Vector3 pushDirection)
    //{
    //    Debug.LogError("Calculate");
    //}

    private void PushObject(GameObject character)
    {
        Debug.LogError(string.Format("Push {0} by {1}", character.name, pushLength));
        character.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushLength);
    }
}
