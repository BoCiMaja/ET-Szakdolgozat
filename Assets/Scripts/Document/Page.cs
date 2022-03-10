using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Page", menuName = "Document/Page")]
public class Page : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    public Sprite Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    //Ha szükséges így lehet bõvíteni
}
