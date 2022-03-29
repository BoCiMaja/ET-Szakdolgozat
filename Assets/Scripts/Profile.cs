using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
    public Profile(ProfileData profile)
    {
        this.Id = profile.Id;
        this.LastSave = profile.LastSave;
    }

    private string id;
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    private DateTime lastSave;
    public DateTime LastSave
    {
        get { return lastSave; }
        set { lastSave = value; }
    }

    private double gameTime;
    public double GameTime
    {
        get { return gameTime; }
        set { gameTime = value; }
    }
}
