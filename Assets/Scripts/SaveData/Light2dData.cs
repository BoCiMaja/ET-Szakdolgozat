using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[Serializable]
public struct Light2dData
{
    public Light2dData(Light2D light)
    {
        id = light.GetHashCode().ToString();
        type = light.lightType;
        enabled = light.enabled;
        //position = light.transform.position;
    }

    public string id;

    public Light2D.LightType type;

    //public Vector3 position;

    public bool enabled;
}
