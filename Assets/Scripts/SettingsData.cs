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

    //if !=
    #region Graphics
    //Resolution
    Resolution defaultResolution;
    public Resolution DefaultResolution
    {
        get { return defaultResolution; }
        set { defaultResolution = value; }
    }
    Resolution currentResolution;
    public Resolution CurrentResolution
    {
        get { return currentResolution; }
        set { currentResolution = value; }
    }

    //Quality
    private byte defaultQualityLevel = 10;
    public byte DefaultQualityLevel
    {
        set { defaultQualityLevel = value; }
        get { return defaultQualityLevel; }
    }
    private byte currentQualityLevel;
    public byte CurrentQualityLevel
    {
        set { currentQualityLevel = value; }
        get { return currentQualityLevel; }
    }

    //Fullscreen
    private bool defaultFullscreen = true;
    public bool DefaultFullscreen
    {
        set { currentFullscreen = value; }
        get { return defaultFullscreen; }
    }
    private bool currentFullscreen = true;
    public bool CurrentFullscreen
    {
        set { currentFullscreen = value; }
        get { return currentFullscreen; }
    }

    //Brightness
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
    private float currentbrightness = 1.0f;
    public float CurrentBrightness
    {
        set
        {
            currentbrightness = value;
        }
        get
        {
            return currentbrightness;
        }
    }

    #endregion

    //Audio
    #region Audio
    private float mainVolume = -20.0f;
    public float MainVolume { get { return mainVolume; } set { mainVolume = value; } }

    private float musicVolume = -20.0f;
    public float MusicVolume { get { return musicVolume; } set { musicVolume = value; } }

    private float effectsVolume = -20.0f;
    public float EffectsVolume { get { return effectsVolume; } set { effectsVolume = value; } }



    #endregion
    //Controls - Keyboard
    //Controls Controller
}
