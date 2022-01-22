using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Audio settings")]
    public AudioMixer audioMixer;

    [Header("Graphics settings")]
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Slider brightnessSlider;
    public int aspectRatioWidth = 16;
    public int aspectRatioHeight = 9;

    List<Resolution> screenResolutions;

    private void Start()
    {
        screenResolutions = new List<Resolution>();
        InitializeResolutionDropdown();

        InitializeGraphicsSettingsData();

       
    }

    private void InitializeGraphicsSettingsData()
    {
        brightnessSlider.value = SettingsData.GetInstance().Brightness;
        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    private void InitializeResolutionDropdown()
    {
        Resolution[] tempScreenResolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < tempScreenResolutions.Length; i++)
        {
            if (tempScreenResolutions[i].width == Screen.currentResolution.width
                && tempScreenResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

            if(checkAspectRatio(tempScreenResolutions[i]))
            {
                screenResolutions.Add(tempScreenResolutions[i]);
                string option = tempScreenResolutions[i].ToString();
                options.Add(option);
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public bool checkAspectRatio(Resolution r)
    {
        return 1.0f * r.width / r.height == 1.0f * aspectRatioWidth / aspectRatioHeight;
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

    public void SetBrigthness(float brightness)
    {
        GameSettings.SetBrightness(brightness);
    }
}
