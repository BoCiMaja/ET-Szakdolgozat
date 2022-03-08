using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    #region Static fields



    #endregion

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                CreateInstance();
            return instance;
        }
    }

    #region Static Methods

    private static void CreateInstance()
    {
        InitializeDefaultAudioDatas(instance.audioData = new AudioData(), instance.defaultAudioData = new AudioData());
        throw new System.NotImplementedException();
    }

    private static void InitializeDefaultAudioDatas(AudioData data, AudioData defaultData)
    {
        throw new System.NotImplementedException();
    }

    public static void SetDefaultAudioData()
    {
        throw new System.NotImplementedException();
    }

    #endregion

    #region Fields and properties

    private AudioData audioData;
    public AudioData AudioData { get; set; }

    private AudioData defaultAudioData;
    public AudioData DefaultAuioData { get; set; }

    #endregion
}
