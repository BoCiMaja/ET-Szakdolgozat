using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudioController : MonoBehaviour
{
    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void SetAudioSettingsInScene()
    {
        throw new System.NotImplementedException();
    }

    public static void SetMasterVolume(float volume)
    {
        throw new System.NotImplementedException();
    }

    public static void SetEffectVolume(float volume)
    {
        throw new System.NotImplementedException();
    }

    public static void SetBgmVolume(float volume)
    {
        throw new System.NotImplementedException();
    }

    public static void ApplyAudioSettings(AudioData data)
    {
        //set
        throw new System.NotImplementedException();
    }
}
