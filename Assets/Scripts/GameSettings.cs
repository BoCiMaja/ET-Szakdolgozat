using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameSettings : MonoBehaviour
{
    [Header("Graphics Settings")]
    public int aspectRatioWidth = 16;
    public int aspectRatioHeight = 9;

    static List<Resolution> resolutions;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SettingsData instance = SettingsData.GetInstance();

            resolutions = new List<Resolution>();

            SetResolutions();

            //Beolvasás
            //ha nem sikerül akkor
            //else  ->

            if (SettingsData.GetInstance().DefaultQualityLevel > 8)
            {
                //Vagy paraméter nélkül legyen?
                InitializeDefaultGraphicsDatas(instance);
            }
        }
    }


    //TODO: Load megírásával módosul, Save megírása után
    void Start()
    {
    }

    public void LoadSettingsData()
    {

    }

    public static void SetSettingsDataInScenes()
    {
        SetGraphicsSettingsInScenes();
        //SetSoundsSettingsInScenes
    }

    private void SetResolutions()
    {
        resolutions.Clear();

        Resolution[] tempScreenResolutions = Screen.resolutions;

        for (int i = 0; i < tempScreenResolutions.Length; i++)
        {
            if (checkAspectRatio(tempScreenResolutions[i]))
            {
                resolutions.Add(tempScreenResolutions[i]);
            }
        }

        if (resolutions.Count <= 0)
            resolutions.AddRange(tempScreenResolutions);
    }
    public static Resolution[] GetResolutions()
    {
        return resolutions.ToArray();
    }
    public static Resolution GetResolutionByIndex(int index)
    {
        return resolutions[index];
    }

    #region Graphics methods
    private void InitializeDefaultGraphicsDatas(SettingsData instance)
    {
        if (!checkAspectRatio(instance.DefaultResolution))
        {
            instance.DefaultResolution = resolutions[resolutions.Count - 1];
            instance.CurrentResolution = resolutions[resolutions.Count - 1];
        }
        else
        {
            instance.DefaultResolution = Screen.currentResolution;
            instance.CurrentResolution = Screen.currentResolution;
        }
        instance.DefaultQualityLevel = System.Convert.ToByte(QualitySettings.GetQualityLevel());
        instance.CurrentQualityLevel = System.Convert.ToByte(QualitySettings.GetQualityLevel());
        instance.DefaultFullscreen = true; //FullScreenMode.
        instance.CurrentFullscreen = true; //FullScreenMode.
        instance.DefaultBrightness = 1.0f;
        instance.CurrentBrightness = 1.0f;
    }

    private static void SetGraphicsSettingsInScenes()
    {
        Light2D[] lights = FindObjectsOfType<Light2D>();

        //Brightness
        GraphicsLoaderManager.setBrigthnessToLights(lights, SettingsData.GetInstance().CurrentBrightness);
    }

    public static void SetBrightness(float brightness)
    {
        SettingsData.GetInstance().CurrentBrightness = brightness;
    }

    public static void SetResolution(Resolution resolution)
    {
        SettingsData.GetInstance().CurrentResolution = resolution;
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public static void SetResolutionByIndex(int index)
    {
        SetResolution(resolutions[index]);
    }

    public static void SetQualityLevel(byte qualityLevel)
    {
        SettingsData.GetInstance().CurrentQualityLevel = qualityLevel;
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public static void SetFullscreen(bool isFullScreen)
    {
        SettingsData.GetInstance().CurrentFullscreen = isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public bool checkAspectRatio(Resolution r)
    {
        return 1.0f * r.width / r.height == 1.0f * aspectRatioWidth / aspectRatioHeight;
    }
    #endregion
}
