using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    public  int RockCount
    {
        get
        {
            //Ha elszeparálja a funkciókat MÓDISÍTANI!
            PlayerActions rockThrowing = gameObject.GetComponent<PlayerActions>();
            if (rockThrowing != null)
                return rockThrowing.ammo;

            return 0;
        }
        private set
        {
            PlayerActions rockThrowing = gameObject.GetComponent<PlayerActions>();
            if (rockThrowing != null)
                rockThrowing.ammo = value;
        }
    }

    private void OnDestroy()
    {
        SceneSessionManager.OnPlayerDestroyed(this);
    }

    internal void SetPlayerData(PlayerData data)
    {
        RockCount = data.rockCount;
    }
}
