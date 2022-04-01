using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUIScript : MonoBehaviour
{
    public void SaveGraphics()
    {
        GameSessionManager.Save();
    }

    public void LoadGraphics()
    {
        GameSessionManager.LoadSessionFromFile();
    }
}
