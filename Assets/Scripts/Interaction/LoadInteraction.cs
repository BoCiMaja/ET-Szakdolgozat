using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInteraction : Interactable
{
    public string SceneToLoad = "MainMenu";

    public override void Interact()
    {
        SoundManager.GetInstance().Play("OpenDoor");
        //GameSession.SaveAtPosition(this.transform.position);
        SceneManager.LoadScene(SceneToLoad);
        //SceneLoader.LoadNextScene(SceneToLoad);
    }
}
