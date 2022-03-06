using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsManager
{
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
        if (aspectRatio == null)
            SetAspectRatio(16, 9);
        resolutions = new List<Resolution>();
        SetResolutions(resolutions);

        instance.graphicsData = new GraphicsData();
        
        //Beolvasás
        //ha nem sikerül akkor
        //else
        //catch(Exception e)
        //{

            InitializeDefaultGraphicsDatas(instance.graphicsData = new GraphicsData(), instance.defaultGraphicsData = new GraphicsData());
        //}
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
        return GetResolutionIndex(instance.graphicsData.Resolution);
    }

    public static int GetResolutionIndex(Resolution  resolution)
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
        return Instance.graphicsData.Resolution;
    }

    private static void InitializeDefaultGraphicsDatas(GraphicsData data, GraphicsData defaultData)
    {
        data.Resolution = defaultData.Resolution = resolutions[resolutions.Count - 1];
        data.QualityLevel = defaultData.QualityLevel = byte.Parse(QualitySettings.GetQualityLevel().ToString());
        data.Fullscreen = defaultData.Fullscreen = true; //FullScreenMode.
        data.Brightness = defaultData.Brightness = 1.0f;
    }

    public static void SetDefaultGraphics()
    {
        instance.graphicsData = instance.defaultGraphicsData;
        SceneGraphicsController.ApplyGraphicsSettings(instance.GraphicsData);
    }

    #endregion

    #region Datas and properties

    private GraphicsData graphicsData;
    public GraphicsData GraphicsData
    {
        get { return graphicsData; }
        set 
        { 
            if(resolutions.Contains(value.Resolution))
                graphicsData = value;
        }
    }

    private GraphicsData defaultGraphicsData;
    public GraphicsData DefaultGraphicsData
    {
        get { return defaultGraphicsData; }
        private set { defaultGraphicsData = value; }
    }

    #endregion
}
