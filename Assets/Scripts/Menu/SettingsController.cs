using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    [Header("Audio settings")]
    public AudioMixer audioMixer;
    public TMP_Text masterVolumeText;

    //[SerializeField] private
    [Header("Graphics settings")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Slider brightnessSlider;
    public TMP_Text brightnessText = null;
    public int aspectRatioWidth = 16;
    public int aspectRatioHeight = 9;

    private List<Resolution> screenResolutions;

    private void Start()
    {
        screenResolutions = new List<Resolution>();

        //Graphics
        InitializeResolutionDropdown();
        InitializeGraphicsSettingsData();
    }

    #region Graphics
    private void InitializeGraphicsSettingsData()
    {
        brightnessSlider.value = SettingsData.GetInstance().Brightness;
        brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightnessSlider.value * 100));
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
            if(checkAspectRatio(tempScreenResolutions[i]))
            {
                screenResolutions.Add(tempScreenResolutions[i]);
            }
        }

        if (screenResolutions.Count <= 0)
            screenResolutions.AddRange(tempScreenResolutions);

        for (int i = 0; i < screenResolutions.Count; i++)
        {
            if (screenResolutions[i].width == Screen.currentResolution.width
                && screenResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

            options.Add(screenResolutions[i].ToString());
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
        brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightnessSlider.value * 100));
    }

    #endregion

    #region Audio
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    #endregion
}
