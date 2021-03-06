using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public static class GraphicsLoader
{

    #region Brightness

    public static void setBrigthnessToLights(Light2D[] lights, Light2D.LightType lightType)
    {
        setBrigthnessToLights(lights, lightType, GraphicsManager.Instance.GraphicsSettings.Brightness);
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
        setBrigthnessToLights(lights, GraphicsManager.Instance.GraphicsSettings.Brightness);
    }

    public static void setBrigthnessToLights(Light2D[] lights, float brigthness)
    {
        foreach (Light2D light in lights)
        {
            // *= ha valahol m?shogy kell be?ll?tani
            light.intensity = brigthness;
        }
    }

    #endregion
}
