using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
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
        SettingsData.GetInstance();
    }

    public static void LoadSettingsData()
    {

    }

    public static void SetBrightness(float brightness)
    {
        SettingsData.GetInstance().Brightness = brightness;
    }
}
