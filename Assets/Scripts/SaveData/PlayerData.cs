using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PlayerData //: ISaveable
{
    //private PlayerData(Player player)
    //{
    //    position = player.transform.position;
    //    rockCount = player.rockCount;
    //}

    private PlayerData(PlayerData playerData)
    {
        rockCount = playerData.rockCount;
    }
    
    public ushort rockCount;

    //public void Load(ISaveable data)
    //{
    //    if (!(data is PlayerData))
    //        throw new Exception("The paramater's type doesn't PlayerData.");

    //    PlayerData loadedData = data as PlayerData;
    //    this.position = loadedData.position;
    //    this.rockCount = loadedData.rockCount;
    //}
}
