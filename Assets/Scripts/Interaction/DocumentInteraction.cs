using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DocumentInteraction : Interactable
{
    Sprite spriteToShow;

    private void Start()
    {
        spriteToShow = GetComponent<SpriteRenderer>().sprite;
    }

    public override void Interact()
    {
        throw new System.NotImplementedException();
    }
}
