using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    //statc instancde tárolása?
    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if(instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartNewGame()
    {
        //új alapértékes PlayerData
        //mentés létrehozása
    }

    //TODO
    private void Start()
    {
        LoadPlayerData();
    }

    //TODO: Load megírásával módosul, Save megírása után
    PlayerData actualPlayerData;
    PlayerData savedPlayerData; //for checkpoints

    //Halál alkalmával és continue alkalmával
    private void LoadPlayerData()
    {
        savedPlayerData = PlayerData.LoadPlayerData();
    }
}
