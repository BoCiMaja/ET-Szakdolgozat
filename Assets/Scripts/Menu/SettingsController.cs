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
    public Toggle fullscreenToggle;

    private void Start()
    {
        InitializeGraphicsSettingsData();
        //InitializeSoundsSettingsData()
    }

    #region Graphics
    private void InitializeGraphicsSettingsData()
    {
        InitializeResolutionDropdown();
        SettingsData settings = SettingsData.GetInstance();
        brightnessSlider.value = settings.CurrentBrightness;
        brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightnessSlider.value * 100));
        SetBrigthness(brightnessSlider.value);
        qualityDropdown.value = settings.CurrentQualityLevel;
        SetQuality(qualityDropdown.value);
        fullscreenToggle.isOn = settings.CurrentFullscreen;
        SetFullScreen(fullscreenToggle.isOn);
    }

    //TODO: index szepites
    private void InitializeResolutionDropdown()
    {
        Resolution[] resolutions = GameSettings.GetResolutions();
        Resolution currentResolution = SettingsData.GetInstance().CurrentResolution;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = -1;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width
                && resolutions[i].height == currentResolution.height)
            {
                currentResolutionIndex = i;
            }

            options.Add(resolutions[i].ToString());
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        GameSettings.SetResolutionByIndex(resolutionIndex);
    }

    public void SetQuality(int qualityIndex)
    {
        GameSettings.SetQualityLevel((byte)qualityIndex);
    }

    public void SetFullScreen(bool isFullSccreen)
    {
        GameSettings.SetFullscreen(isFullSccreen);
    }

    public void SetBrigthness(float brightness)
    {
        GameSettings.SetBrightness(brightness);
        brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightness * 100));
    }

    #endregion

    #region Audio
    #endregion
}
