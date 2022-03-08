using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioData
{
    private float masterVolume;
    public float MasterVolume { get; set; }

    private float bgmVolume;
    public float BgmVolume { get; set; }

    private float effectVolume;
    public float EffectVolume { get; set; }
}
