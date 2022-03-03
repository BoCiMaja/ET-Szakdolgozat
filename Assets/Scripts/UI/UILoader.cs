using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    public string uiSceneName = "UI";

    private void Start()
    {
        if(!SceneManager.GetSceneByName(uiSceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(uiSceneName, LoadSceneMode.Additive);
        }
    }
}
