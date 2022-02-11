using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadMainMenu()
    {
        LoadWithLoadingScreenAsync("MainMenu");
    }

    public static void LoadNewGame(string sceneToLoad)
    {
        LoadWithLoadingScreenAsync(sceneToLoad);
    }
    
    public static void Continue(string sceneToLoad)
    {
        LoadWithLoadingScreenAsync(sceneToLoad);
    }
    
    public static void LoadNextScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
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
