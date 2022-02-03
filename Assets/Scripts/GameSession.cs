using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    //statc instancde t�rol�sa?
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
        //�j alap�rt�kes PlayerData
        //ment�s l�trehoz�sa
    }

    //TODO
    private void Start()
    {
        LoadPlayerData();
    }

    //TODO: Load meg�r�s�val m�dosul, Save meg�r�sa ut�n
    PlayerData actualPlayerData;
    PlayerData savedPlayerData; //for checkpoints

    //Hal�l alkalm�val �s continue alkalm�val
    private void LoadPlayerData()
    {
        savedPlayerData = PlayerData.LoadPlayerData();
    }
}
