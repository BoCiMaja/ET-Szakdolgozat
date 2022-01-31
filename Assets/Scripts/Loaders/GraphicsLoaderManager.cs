using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public static class GraphicsLoaderManager
{

    #region Brightness

    public static void setBrigthnessToLights(Light2D[] lights, Light2D.LightType lightType)
    {
        setBrigthnessToLights(lights, lightType, SettingsData.GetInstance().CurrentBrightness);
    }

    public static void setBrigthnessToLights(Light2D[] lights, Light2D.LightType lightType, float brightness)
    {
        List<Light2D> certainTypesOfLights = new List<Light2D>();

        foreach (Light2D light in lights)
        {
            if (light.lightType == lightType)
                certainTypesOfLights.Add(light);
        }

        setBrigthnessToLights(certainTypesOfLights.ToArray(), brightness);
    }

    public static void setBrigthnessToLights(Light2D[] lights)
    {
        setBrigthnessToLights(lights, SettingsData.GetInstance().CurrentBrightness);
    }

    public static void setBrigthnessToLights(Light2D[] lights, float brigthness)
    {
        foreach (Light2D light in lights)
        {
            light.intensity *= brigthness;
        }
    }

    #endregion
}
