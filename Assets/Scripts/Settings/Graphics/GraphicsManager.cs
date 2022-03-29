using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsManager
{
    #region Static fields

    private static List<Resolution> resolutions;
    public static Resolution[] Resolutions
    {
        get { return resolutions.ToArray(); }
    }

    private static Tuple<float, float> aspectRatio;
    public static void SetAspectRatio(float width, float height)
    {
        aspectRatio = new Tuple<float, float>(width, height);
    }

    private static string path = "graphics.bin";

    public static event Action<GraphicsSettings> OnGraphicsChange;

    #endregion

    private static GraphicsManager instance;
    public static GraphicsManager Instance
    {
        get
        {
            if (instance == null)
                CreateInstance();
            return instance;
        }
    }

    #region Static Methods

    private static void CreateInstance()
    {
        instance = new GraphicsManager();
        OnGraphicsChange += SaveSettings;

        if (aspectRatio == null)
            SetAspectRatio(16, 9);
        resolutions = new List<Resolution>();
        SetResolutions(resolutions);
        
        instance.DefaultGraphicsSettings = new GraphicsSettings();
        instance.DefaultGraphicsSettings.Resolution = resolutions[resolutions.Count - 1];

        GraphicsData data;

        try
        {
            data = SaveSystem.LoadSettings<GraphicsData>(path);
            instance.GraphicsSettings = new GraphicsSettings(data);
        }
        catch
        {
            SetDefaultGraphics();
        }

    }

    private static void SetResolutions(List<Resolution> resolutions)
    {
        resolutions.Clear();

        Resolution[] tempScreenResolutions = Screen.resolutions;

        for (int i = 0; i < tempScreenResolutions.Length; i++)
        {
            if (IsAspectRatioAppropriate(tempScreenResolutions[i]))
            {
                resolutions.Add(tempScreenResolutions[i]);
            }
        }

        if (resolutions.Count <= 0)
            resolutions.AddRange(tempScreenResolutions);
    }

    public static bool IsAspectRatioAppropriate(Resolution r)
    {
        return 1.0f * r.width / r.height == 1.0f * aspectRatio.Item1 / aspectRatio.Item2;
    }

    public static Resolution GetResolutionByIndex(int index)
    {
        return resolutions[index];
    }

    public static int GetCurrentResolutionIndex()
    {
        return GetResolutionIndex(instance.graphicsSettings.Resolution);
    }

    public static int GetResolutionIndex(Resolution resolution)
    {
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (resolutions[i].width == resolution.width &&
               resolutions[i].height == resolution.height)
                return i;
        }
        return -1;
    }

    public static Resolution GetCurrentResolution()
    {
        return Instance.graphicsSettings.Resolution;
    }

    public static void SetDefaultGraphics()
    {
        instance.graphicsSettings = new GraphicsSettings(instance.defaultGraphicsSettings);
        OnGraphicsChange.Invoke(instance.GraphicsSettings);
    }

    public static void ApplyGraphicsSettings(GraphicsSettings settings)
    {
        instance.GraphicsSettings = new GraphicsSettings(settings);
        OnGraphicsChange.Invoke(instance.GraphicsSettings);
    }

    public static void SaveSettings(GraphicsSettings settings)
    {
        SaveSystem.SaveSettings(new GraphicsData(instance.GraphicsSettings), path);
    }

    #endregion

    #region Fields and properties

    private GraphicsSettings graphicsSettings;
    public GraphicsSettings GraphicsSettings
    {
        get { return graphicsSettings; }
        private set 
        { 
            if(GraphicsManager.resolutions.Contains(value.Resolution))
                graphicsSettings = value;
            else throw new Exception("Cannot find resolution.");
        }
    }

    private GraphicsSettings defaultGraphicsSettings;
    public GraphicsSettings DefaultGraphicsSettings
    {
        get { return defaultGraphicsSettings; }
        private set { defaultGraphicsSettings = value; }
    }

    #endregion
}
