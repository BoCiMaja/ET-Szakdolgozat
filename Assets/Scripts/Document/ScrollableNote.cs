using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scrollable Note", menuName = "Document/Scrollable Note")]
public class ScrollableNote : Note
{
    [SerializeField] private Page[] pages;
    public Page[] Pages
    {
        get { return pages; }
        set { pages = value; }
    }
    public override Page ActivePage
    { 
        get
        {
            return pages[currentPage];
        } 
    }

    private byte currentPage;
    public byte CurrentPage
    {
        private get { return currentPage; }
        set
        {
            if (value > pages.Length - 1)
                currentPage = byte.Parse((pages.Length - 1).ToString());
            else if (value < 0)
                currentPage = 0;
            else
                currentPage = value;
        }
    }

    [SerializeField] private bool isDoubleSided;
    public bool IsDoubleSided
    {
        get { return isDoubleSided; }
        set
        {
            if (pages.Length == 1)
            {
                isDoubleSided = false;
                return;
            }
            isDoubleSided = value;
        }
    }

    [SerializeField] AudioClip turnPage;
    public AudioClip TurnPage
    {
        get { return turnPage; }
        set { turnPage = value; }
    }

    public static ScrollableNote operator++(ScrollableNote note)
    {
        note.CurrentPage++;
        return note;
    }

    public static ScrollableNote operator--(ScrollableNote note)
    {
        note.CurrentPage--;
        return note;
    }
}
