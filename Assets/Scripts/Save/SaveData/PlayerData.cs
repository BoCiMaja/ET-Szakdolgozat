using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PlayerData
{
    public PlayerData(PlayerDataController player)
    {
        rockCount = Convert.ToUInt16(player.RockCount);
    }

    public ushort rockCount;
}
