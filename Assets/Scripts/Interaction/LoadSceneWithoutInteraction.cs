using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneWithoutInteraction : MonoBehaviour
{
    public string sceneToLoad = "MainMenu";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneLoader.LoadNextScene(sceneToLoad);
    }
}
