using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public struct GraphicsData : ISaveable
{
    public GraphicsData(GraphicsSettings settings)
    {
        resolution = (ResolutionData)settings.Resolution;
        qualityLevel = settings.QualityLevel;
        fullscreen = settings.Fullscreen;
        brightness = settings.Brightness;
    }

    private GraphicsData(GraphicsData data)
    {
        resolution = data.resolution;
        qualityLevel = data.qualityLevel;
        fullscreen = data.fullscreen;
        brightness = data.brightness;
    }

    public ResolutionData resolution;
    public byte qualityLevel;
    public bool fullscreen;
    public float brightness;

    public void Load(ISaveable data)
    {
        if (!(data is GraphicsData))
            throw new Exception("The parameter's type doesn't GraphicsData");

        GraphicsData loadedData = (GraphicsData)data;// as GraphicsData;
        this.resolution = loadedData.resolution;
        this.qualityLevel = loadedData.qualityLevel;
        this.fullscreen = loadedData.fullscreen;
        this.brightness = loadedData.brightness;
    }

    //public static explicit operator GraphicsSettings(GraphicsData data)
    //{
    //    return new GraphicsSettings(data);
    //}

    //public static explicit operator GraphicsData(GraphicsSettings settings)
    //{
    //    return new GraphicsData(settings);
    //}

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Resolution: {0}\n", resolution);
        sb.AppendFormat("Quality: {0}\n", qualityLevel);
        sb.AppendFormat("Fullscreen: {0}\n", fullscreen);
        sb.AppendFormat("Brightness: {0}\n", brightness);
        return sb.ToString();
    }
}
