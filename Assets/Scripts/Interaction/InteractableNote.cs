using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InteractableNote : Interactable
{
    public static event Action<Note> OnNoteInteraction;

    [SerializeField] Note noteToShow;

    private void Start()
    {
        if (noteToShow == null)
            throw new System.Exception("There's nothing to show! " + gameObject.name);
    }

    public override void Interact()
    {
        if (noteToShow is ScrollableNote)
            (noteToShow as ScrollableNote).CurrentPage = 0;

        Debug.Log("Interact with " + gameObject.name);

        OnNoteInteraction?.Invoke(this.noteToShow);
    }
}
