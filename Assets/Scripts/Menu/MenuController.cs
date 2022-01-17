using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string newGameScene;
    //private Scene levelToLoad;

    public void LoadNewGameLevel()
    {
        SceneLoader sl = gameObject.AddComponent<SceneLoader>();
        sl.sceneToLoad = newGameScene;
        sl.LoadNewGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
