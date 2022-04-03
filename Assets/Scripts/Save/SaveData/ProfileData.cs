using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ProfileData
{
    public ProfileData(Profile profile)
    {
        Id = profile.Id;
        LastSave = profile.LastSave;
        GameTime = profile.GameTime;
    }

    public string Id;
    public DateTime LastSave;
    public double GameTime;
}
