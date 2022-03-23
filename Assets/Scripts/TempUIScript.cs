using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUIScript : MonoBehaviour
{
    public void SaveGraphics()
    {
        GraphicsData data = new GraphicsData(GraphicsManager.Instance.GraphicsSettings);
        SaveSystem.SaveSettings(data, "graphics.bin");
    }

    public void LoadGraphics()
    {
        GraphicsData data = new GraphicsData(GraphicsManager.Instance.DefaultGraphicsSettings);
        SaveSystem.LoadSettings(ref data, "graphics.bin");
    }
}
