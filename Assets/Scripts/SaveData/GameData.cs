using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[Serializable]
public struct GameData : ISaveable
{
    //public GameData()
    //{
       
    //}

    public GameData(GameSession gameSession)
    {
        //playerData = new PlayerData(gameSession.player);

        Path = gameSession.Path;

        Light2D[] lights = gameSession.Lights;
        LightsDatas = new Light2dData[lights.Length];
        SetLightsDatas(lights);
    }

    //public PlayerData playerData;

    public Light2dData[] LightsDatas;
    private void SetLightsDatas(Light2D[] lights)
    {
        for (int i = 0; i < lights.Length; i++)
            LightsDatas[i] = new Light2dData(lights[i]);
    }

    //public string ActualScene;

    public string Path;

    public void Load(ISaveable data)
    {
        if (!(data is GameData))
            throw new Exception("The parameter's type doesn't GameData");

        GameData loadedData = (GameData)data;// as GameData;
        //this.playerData = loadedData.playerData;
        this.LightsDatas = loadedData.LightsDatas;
        //this.ActualScene = loadedData.ActualScene;
        this.Path = loadedData.Path;
    }

}
