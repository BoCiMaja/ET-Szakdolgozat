using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] screenResolutions;

    private void Start()
    {
        InitializeResolutionDropdown();

        //SetQuality(QualitySettings.GetQualityLevel());

    }

    private void InitializeResolutionDropdown()
    {
        screenResolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < screenResolutions.Length; i++)
        {
            if (screenResolutions[i].width == Screen.currentResolution.width
                && screenResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

            string option = createOption(i);
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private string createOption(int i)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(screenResolutions[i].width);
        builder.Append("x");
        builder.Append(screenResolutions[i].height);

        string option = builder.ToString();
        return option;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = screenResolutions[resolutionIndex];
        Debug.Log(resolution);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullSccreen)
    {
        Screen.fullScreen = isFullSccreen;
    }

}
