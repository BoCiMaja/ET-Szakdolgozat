using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Single Note", menuName = "Document/Single Note")]
public class SingleNote : Note
{
    [SerializeField] private Page page;
    public Page Page
    {
        get { return page; }
        set { page = value; }
    }

    public override Page ActivePage
    {
        get { return page; }
    }
}
