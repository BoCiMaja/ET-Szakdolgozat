using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UINoteController : MonoBehaviour
{
    [SerializeField] private NotePanel notePanel;

    private void Awake()
    {
        InteractableNote.OnNoteInteraction += HandleSelectedNoteChanged;
    }

    private void OnDestroy()
    {
        InteractableNote.OnNoteInteraction -= HandleSelectedNoteChanged;
    }

    private void HandleSelectedNoteChanged(Note note)
    {
        if (notePanel != null)
            notePanel.Bind(note);
    }
}
