using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heaven3Controller : MonoBehaviour
{
   // public PlayerMovement adam;

    private void Start()
    {
        SoundManager.GetInstance().Play("Labor2BGM");
        //SoundManager.GetInstance().Stop("Ambient");
        SoundManager.GetInstance().Stop("Labor1BGM");

    }

    
}
