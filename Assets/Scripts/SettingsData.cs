using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData
{
    private static SettingsData instance;
    public static SettingsData GetInstance()
    {
        if (instance == null)
            instance = new SettingsData();
        return instance;
    }

    //Graphics
    private float defaultBrightness = 1.0f;
    public float DefaultBrightness
    {
        set
        {
            defaultBrightness = value;
        }
        get
        {
            return defaultBrightness;
        }
    }
    private float brightness = 1.0f;
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

    //Audio
    //Controls - Keyboard
    //Controls Controller
}
