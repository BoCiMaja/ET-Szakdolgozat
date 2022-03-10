using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : ScriptableObject
{
    public abstract Page ActivePage { get; }

    [SerializeField] private string label;
    public string Label
    {
        get { return label; }
        set { label = value; }
    }
    public bool HasLabel
    {
        get { return !string.IsNullOrWhiteSpace(label);}
    }

    [SerializeField] private AudioClip pickup;
    public AudioClip Pickup
    {
        get 
        { 
            //if(null) exception
            return pickup; 
        }
        set { pickup = value; }
    }
}
