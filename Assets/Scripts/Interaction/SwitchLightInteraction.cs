using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SwitchLightInteraction : Interactable
{
    [SerializeField] Light2D[] light2Ds;

    public bool on;

    public override void Interact()
    {
        on = true;
        if (on)
        {
            SoundManager.GetInstance().Play("LightOn");
            on = false;
        }
        else
        {
            SoundManager.GetInstance().Play("LightOff");
        }

        //Light2D[] light2Ds = FindObjectsOfType<Light2D>();
        if (light2Ds.Length != 0)
            foreach (Light2D light in light2Ds)
            { 
                light.enabled = !light.enabled;
                Debug.Log(light);
            }
    }
}
