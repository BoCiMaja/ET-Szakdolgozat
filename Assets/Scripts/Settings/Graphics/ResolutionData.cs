using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ResolutionData
{
    public ResolutionData(Resolution resolution)
    {
        width = resolution.width;
        height = resolution.height;
        refreshRate = resolution.refreshRate;
    }

    public int width { get; private set; }

    public int height { get; private set; }
    
    public int refreshRate { get; private set; }

    public static explicit operator Resolution(ResolutionData data)
    {
        Resolution resolution = new Resolution();
        resolution.width = data.width;
        resolution.height = data.height;
        resolution.refreshRate = data.refreshRate;
        return resolution;
    }

    public static explicit operator ResolutionData(Resolution resolution)
    {
        return new ResolutionData(resolution);
    }
}
