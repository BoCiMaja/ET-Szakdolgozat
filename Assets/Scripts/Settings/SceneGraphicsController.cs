using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SceneGraphicsController : MonoBehaviour
{
    [Header("Graphics Settings")]
    public int aspectRatioWidth = 16;
    public int aspectRatioHeight = 9;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void SetGraphicsSettingsInScene()
    {
        Light2D[] lights = FindObjectsOfType<Light2D>();

        //Brightness
        GraphicsLoader.setBrigthnessToLights(lights, GraphicsManager.Instance.GraphicsData.Brightness);
    }

    public static void SetBrightness(float brightness)
    {
        Light2D[] lights = FindObjectsOfType<Light2D>();
        if (lights.Length > 0)
            GraphicsLoader.setBrigthnessToLights(lights,  brightness);
    }

    public static void SetResolution(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public static void SetResolutionByIndex(int index)
    {
        SetResolution(GraphicsManager.GetResolutionByIndex(index));
    }

    public static void SetQualityLevel(byte qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public static void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public static void ApplyGraphicsSettings(GraphicsData data)
    {
        SetBrightness(data.Brightness);
        SetResolution(data.Resolution);
        SetQualityLevel(data.QualityLevel);
        SetFullscreen(data.Fullscreen);
    }
}
