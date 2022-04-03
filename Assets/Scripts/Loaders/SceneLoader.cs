using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static event Action OnLoadNextScene;
    public static event Action OnLoadMainMenu;

    public static void LoadMainMenu()
    {
        if (SceneManager.GetSceneByName("UI").isLoaded)
            SceneManager.UnloadSceneAsync("UI");
        LoadWithLoadingScreenAsync("MainMenu");
        OnLoadMainMenu?.Invoke();
    }

    public static void LoadNewGame(string sceneToLoad)
    {
        LoadWithLoadingScreenAsync(sceneToLoad);
        GameSessionManager.NewGame(sceneToLoad);
    }
    
    public static void Continue(string sceneToLoad)
    {
        LoadWithLoadingScreenAsync(sceneToLoad);
    }
    
    //public static void LoadNextScene(string sceneToLoad)
    //{
    //    SceneManager.LoadScene(sceneToLoad);
    //}

    public static void LoadNextScene(string sceneToLoad)
    {
        if (SceneManager.GetActiveScene().isLoaded)
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        if (SceneManager.GetSceneByName(sceneToLoad).isLoaded == false)
        {
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive).completed += operation =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));
                OnLoadNextScene.Invoke();
            };
        }
    }

    public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private static async void LoadWithLoadingScreenAsync(string sceneToLoad)
    {
        var scene = SceneManager.LoadSceneAsync(sceneToLoad);
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);
            //Progress bar
            //Debug.Log(scene.progress);
        }
        while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        await Task.Yield();
    }
}
