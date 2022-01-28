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

    [SerializeField] private GameObject noSavedGameDialog = null;

    public void LoadNewGameLevel()
    {
        SceneLoader.LoadNewGame(newGameScene);
    }

    public void LoadSavedGame()
    {
        noSavedGameDialog.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
