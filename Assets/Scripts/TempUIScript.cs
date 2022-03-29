using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUIScript : MonoBehaviour
{
    public void SaveGraphics()
    {
        GameSession.SaveSession();
    }

    public void LoadGraphics()
    {
        GameSession.LoadSession();
    }
}
