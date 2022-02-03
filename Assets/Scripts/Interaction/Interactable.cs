using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private float radius = 1.25f;
    public float Radius
    {
        get { return radius; }
        set
        {
            radius = value;
            if (Application.isPlaying)
                ModifyCircleColliderRadius();
        }
    }

    public abstract void Interact();

    private void Start()
    {
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        if(!collider)
        {
            CircleCollider2D circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
        circleCollider2D.radius = radius;
        circleCollider2D.isTrigger = true;
        }
    }        

    private void ModifyCircleColliderRadius()
    {
        if (gameObject.GetComponent<CircleCollider2D>())
            gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }
}
