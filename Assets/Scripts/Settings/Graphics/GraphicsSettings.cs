using System.Text;
using UnityEngine;

public class GraphicsSettings 
{
    public GraphicsSettings()
    {
        Resolution = Screen.currentResolution;
        QualityLevel = byte.Parse(QualitySettings.GetQualityLevel().ToString());
        Fullscreen = true;
        Brightness = 1.0f;
    }

    public GraphicsSettings(Resolution resolution, byte qualityLevel, bool fullscreen, float brightness)
    {
        this.Resolution = resolution;
        this.QualityLevel = qualityLevel;
        this.Fullscreen = fullscreen;
        this.Brightness = brightness;
    }

    public GraphicsSettings(GraphicsData data)
        :this((Resolution)data.resolution, data.qualityLevel, data.fullscreen, data.brightness)
    {
    }

    public GraphicsSettings(GraphicsSettings settings)
        : this(settings.resolution, settings.qualityLevel, settings.fullscreen, settings.brightness)
    {
    }

    //Resolution
    private Resolution resolution;
    public Resolution Resolution
    {
        get { return resolution; }
        set { resolution = value; }
    }

    //Quality
    private byte qualityLevel;
    public byte QualityLevel
    {
        set 
        {
            if (value > QualitySettings.names.Length)
            {
                Debug.LogError("Nincs ilyen quality level.");
                qualityLevel = byte.Parse(QualitySettings.GetQualityLevel().ToString());
            }
            else
                qualityLevel = value; 
        }
        get { return qualityLevel; }
    }

    //Fullscreen
    private bool fullscreen = true;
    public bool Fullscreen
    {
        set { fullscreen = value; }
        get { return fullscreen; }
    }

    //Brightness
    private float brightness;
    public float Brightness
    {
        set
        {
            brightness = value;
        }
        get
        {
            return brightness;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Resolution: {0}\n", Resolution);
        sb.AppendFormat("Quality: {0}\n", QualityLevel);
        sb.AppendFormat("Fullscreen: {0}\n", Fullscreen);
        sb.AppendFormat("Brightness: {0}\n", Brightness);
        return sb.ToString();
    }
}
