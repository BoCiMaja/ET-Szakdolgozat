using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameSettings : MonoBehaviour
{
    public float DefaultBrightness = 1.0f;

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
        }
    }

    //TODO: Load megírásával módosul, Save megírása után
    void Start()
    {
        SettingsData instance = SettingsData.GetInstance();
        instance.DefaultBrightness = 1.0f;
    }

    public void LoadSettingsData()
    {

    }

    public static void SetSettingsData()
    {
        SetGraphicsSettings();

    }

    private static void SetGraphicsSettings()
    {
        Light2D[] lights = FindObjectsOfType<Light2D>();

        //Brightness
        GraphicsLoaderManager.setBrigthnessToLights(lights, SettingsData.GetInstance().Brightness);
    }

    public static void SetBrightness(float brightness)
    {
        SettingsData.GetInstance().Brightness = brightness;
    }
}
