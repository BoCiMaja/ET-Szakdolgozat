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
        Debug.Log("Handle");
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

    ////private RectTransform maxRectTr;
    //Note noteToShow;
    //byte pageNumber;

    ////private void Start()
    ////{
    ////    //if (image == null)
    ////        //throw new System.Exception("Image can't be null!");
    ////}

    ////private void OnDestroy()
    ////{
    ////    //UIDocumentController.note = null;
    ////}

    //private static void OnNoteChanged()
    //{
    //    //if(note.HasLabel && label)
    //    //Ha van címke akkor label visible, amúgy nem.
    //    /* if(note.hasLabel && labelText != null)
    //     *      labelText.text = note.Label
    //     */

    //    // Ha a new image aspect ratio-ja kisebb mint a defaultRect-é akkor tömzsibb így a kisebb oldalt
    //    // kell hozzá igazítanunk
    //    // Amúgy meg a nagyobbat
    //}

    //public static void ShowNote(Note note)
    //{
    //    //UIDocumentController.note = note;
    //    OnNoteChanged();
    //}

    //public static void HideNote()
    //{
    //    //note = null;
    //    OnNoteChanged();
    //}
}
