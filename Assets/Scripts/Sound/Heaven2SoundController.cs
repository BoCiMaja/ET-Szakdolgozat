using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heaven2SoundController : MonoBehaviour
{
    private void Start()
    {
        SoundManager.GetInstance().Play("Labor1BGM");
        //SoundManager.GetInstance().Stop("Ambient");
        SoundManager.GetInstance().Stop("BGM");
    }
}
