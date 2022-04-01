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

    public override bool Equals(object obj)
    {
        if (obj is Light2dData)
        {
            Light2dData masik = (Light2dData)obj;
            return masik.id == this.id && this.type == masik.type;
        }
        if(obj is Light2D)
        {
            Light2D light = (Light2D)obj;
            return light.GetHashCode().ToString() == this.id && light.lightType == this.type;
        }
        return false;
    }
}
