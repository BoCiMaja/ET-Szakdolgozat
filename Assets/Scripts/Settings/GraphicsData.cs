using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GraphicsData
{
    //Resolution
    Resolution resolution;
    public Resolution Resolution
    {
        get { return resolution; }
        set { resolution = value; }
    }

    //Quality
    private byte qualityLevel;
    public byte QualityLevel
    {
        set 
        {
            if (value > QualitySettings.names.Length)
            {
                Debug.LogError("Nincs ilyen quality level.");
                qualityLevel = byte.Parse(QualitySettings.GetQualityLevel().ToString());
            }
            else
                qualityLevel = value; 
        }
        get { return qualityLevel; }
    }

    //Fullscreen
    private bool fullscreen = true;
    public bool Fullscreen
    {
        set { fullscreen = value; }
        get { return fullscreen; }
    }

    //Brightness
    private float brightness;
    public float Brightness
    {
        set
        {
            brightness = value;
        }
        get
        {
            return brightness;
        }
    }
}
