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

    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private Note boundNote;

    public void Bind(Note note)
    {
        if (boundNote == null)
            Time.timeScale = 0;

        boundNote = note;

        if (boundNote != null)
        {
            panelRoot.SetActive(true);
            FindObjectOfType<SoundManager>().Play("BookView");

            nextButton.gameObject.SetActive(boundNote is ScrollableNote);
            previousButton.gameObject.SetActive(boundNote is ScrollableNote);

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

        if (note is ScrollableNote)
            HandleScrollPageChanged(note as ScrollableNote);
    }

    private void HandleScrollPageChanged(ScrollableNote note)
    {
        previousButton.interactable = !note.IsActiveTheFirstPage;
        nextButton.interactable = !note.IsActiveTheLastPage;
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
            FindObjectOfType<SoundManager>().Play("BookFlipPage");
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
            FindObjectOfType<SoundManager>().Play("BookFlipPage");
        }
    }

    public void Close()
    {
        FindObjectOfType<SoundManager>().Play("BookClose");
        Time.timeScale = 1;
        this.Bind(null);
    }
}
