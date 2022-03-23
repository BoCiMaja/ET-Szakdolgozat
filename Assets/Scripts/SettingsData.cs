using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SettingsData
{
    private static SettingsData instance;
    public static SettingsData GetInstance()
    {
        if (instance == null)
            instance = new SettingsData();
        return instance;
    }

    GraphicsSettings graphicsData;
    GraphicsSettings defaultGraphicsData;
}
