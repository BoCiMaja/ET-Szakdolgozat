using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotePanel : MonoBehaviour
{
    [SerializeField] private GameObject panelRoot;
    [SerializeField] private Image noteImage;
    [SerializeField] private TMP_Text noteLabelText;

    private Note boundNote;

    //private void OnDestroy()
    //{
    //    if (boundNote != null) ;
    //    //NoteHandler.Instance.OnNoteChanged += HandleNoteChanged;
    //}

    public void Bind(Note note)
    {
        //if (boundNote != null)
            //boundNote.OnHealthChanged -= HandleHealthChanged;

        boundNote = note;

        if (boundNote != null)
        {
            panelRoot.SetActive(true);
            //_boundEntity.OnHealthChanged += HandleHealthChanged;
            HandlePageChanged(boundNote);
        }
        else
        {
            panelRoot.SetActive(false);
        }
    }

    private void HandlePageChanged(Note note)
    {
        noteImage.sprite = note.ActivePage.Sprite;
        if (noteLabelText != null && note.HasLabel)
            noteLabelText.SetText(note.Label);
    }

    public void NextPage()
    {
        if (boundNote is ScrollableNote)
        {
            //(boundNote as ScrollableNote)++;
            
            ScrollableNote note = boundNote as ScrollableNote;
            note++;

            //(boundNote as ScrollableNote).CurrentPage++;

            HandlePageChanged(boundNote);
        }
    }

    public void PreviousPage()
    {
        if (boundNote is ScrollableNote)
        {
            //(boundNote as ScrollableNote)++;

            ScrollableNote note = boundNote as ScrollableNote;
            note--;

            //(boundNote as ScrollableNote).CurrentPage++;

            HandlePageChanged(boundNote);
        }
    }

    public void Close()
    {
        this.Bind(null);
    }
}
