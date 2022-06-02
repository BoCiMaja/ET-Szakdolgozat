using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInteraction : Interactable
{
    public string SceneToLoad = "MainMenu";

    public override void Interact()
    {
        SoundManager.GetInstance().Play("OpenDoor");
        //GameSession.SaveAtPosition(this.transform.position);
        SceneLoader.LoadNextScene(SceneToLoad);
    }
}
