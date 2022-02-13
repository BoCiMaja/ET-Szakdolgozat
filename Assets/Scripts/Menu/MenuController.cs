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
        SoundManager.GetInstance().Stop("BGM");
    }

    [SerializeField] private GameObject noSavedGameDialog = null;

    public void LoadNewGameLevel()
    {
        SceneLoader.LoadNewGame(newGameScene);
        SoundManager.GetInstance().Play("BGM");
        SoundManager.GetInstance().Stop("MenuBGM");
    }

    public void LoadSavedGame()
    {
        noSavedGameDialog.SetActive(true);
        SoundManager.GetInstance().Play("BGM");
        SoundManager.GetInstance().Stop("MenuBGM");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
