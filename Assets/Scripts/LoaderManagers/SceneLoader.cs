using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SceneLoader(string sceneToLoad)
    {
        this.sceneToLoad = sceneToLoad;
    }

    public string sceneToLoad;
    
    public void LoadNewGame()
    {
        LoadWithLoadingScreenAsync();
    }

    public void Continue()
    {
        LoadWithLoadingScreenAsync();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private async void LoadWithLoadingScreenAsync()
    {
        var scene = SceneManager.LoadSceneAsync(sceneToLoad);
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);
            //Progress bar
            Debug.Log(scene.progress);
        }
        while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        await Task.Yield();
    }
}
