using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    CharacterController2D charController;

    private void Start()
    {
        charController = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            CheckInteraction();
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(0.1f, 1f), 0, Vector2.zero);

        foreach (RaycastHit2D hit2D in hits)
        {
            Interactable interactableObject = hit2D.transform.GetComponent<Interactable>();
            if (interactableObject && IsInTheRightDirection(hit2D.transform.position))
            {
                interactableObject.Interact();
                return;
            }
        }
    }

    private bool IsInTheRightDirection(Vector3 position)
    {
        float distance = position.x - transform.position.x;
        if ((distance > 0 && transform.localScale.x > 0) ||
            (distance < 0 && transform.localScale.x < 0))
            return true;
        return false;
    }
}
