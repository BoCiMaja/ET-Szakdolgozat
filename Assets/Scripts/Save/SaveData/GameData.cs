using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[Serializable]
public struct GameData : ISaveable
{
    public GameData(GameSession gameSession)
    {
        ProfileData = new ProfileData(gameSession.Profile);

        PlayerData = gameSession.PlayerData;

        SavePosition = gameSession.SavePosition;

        Path = gameSession.Path;
        ActualScene = gameSession.ActualScene;

        Light2D[] lights = gameSession.Lights;
        LightsDatas = new Light2dData[lights.Length];
        SetLightsDatas(lights);
    }

    public ProfileData ProfileData;

    public PlayerData PlayerData;

    public Vector3 SavePosition;

    public Light2dData[] LightsDatas;
    private void SetLightsDatas(Light2D[] lights)
    {
        for (int i = 0; i < lights.Length; i++)
            LightsDatas[i] = new Light2dData(lights[i]);
    }

    public string ActualScene;

    public string Path;

    public void Load(ISaveable data)
    {
        if (!(data is GameData))
            throw new Exception("The parameter's type doesn't GameData");

        GameData loadedData = (GameData)data;// as GameData;
        this.PlayerData = loadedData.PlayerData;
        this.SavePosition = loadedData.SavePosition;
        this.LightsDatas = loadedData.LightsDatas;
        this.ActualScene = loadedData.ActualScene;
        this.Path = loadedData.Path;
    }

}
