using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string newGameScene;
    private string levelToLoad;

    private void Start()
    {
        SoundManager.GetInstance().Play("MenuBGM");
        SoundManager.GetInstance().Stop("Ambient");
        SoundManager.GetInstance().Stop("BGM");
    }

    [SerializeField] private GameObject noSavedGameDialog = null;

    public void LoadNewGameLevel()
    {
        SceneLoader.LoadNewGame(newGameScene);
        SoundManager.GetInstance().Play("BGM");
        SoundManager.GetInstance().Play("Ambient");
        SoundManager.GetInstance().Stop("MenuBGM");
    }

    public void Continue()
    {
        GameSessionManager.LoadSaves();
    }

    public void Load()
    {
        if (noSavedGameDialog == null)
            throw new System.Exception("Missing 'No saved game' dialog!");


        try
        {
            GameSessionManager.Load();
          ////SceneLoader.Continue(GameSession.Instance.);
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
            noSavedGameDialog.SetActive(true);
        }
    }

    //public void LoadSavedGame()
    //{
    //    noSavedGameDialog.SetActive(true);
    //    if (noSavedGameDialog)
    //    {

    //    }
    //    else
    //    {
    //        SoundManager.GetInstance().Play("BGM");
    //        SoundManager.GetInstance().Stop("MenuBGM");
    //    }
    //}


    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
