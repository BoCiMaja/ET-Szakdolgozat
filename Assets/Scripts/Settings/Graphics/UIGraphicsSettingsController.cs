using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGraphicsSettingsController : MonoBehaviour, IUISettings
{
    //[SerializeField] private
    [Header("Graphics settings")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Slider brightnessSlider;
    public TMP_Text brightnessText = null;
    public Toggle fullscreenToggle;

    private void Start()
    {
        if(GraphicsManager.Instance != null)
            InitializeDatas();
    }

    //Szépítés
    private void InitializeDatas()
    {
        InitializeResolutionDropdown();
        GraphicsData data = GraphicsManager.Instance.GraphicsData;
        brightnessSlider.value = data.Brightness;
        brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightnessSlider.value * 100));
        qualityDropdown.value = data.QualityLevel;
        fullscreenToggle.isOn = data.Fullscreen;
    }

    //TODO: index szepites
    private void InitializeResolutionDropdown()
    {
        Resolution[] resolutions = GraphicsManager.Resolutions;
        Resolution currentResolution = GraphicsManager.Instance.GraphicsData.Resolution;

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
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        SceneGraphicsController.SetResolutionByIndex(resolutionIndex);
    }

    public void SetQuality(int qualityIndex)
    {
        SceneGraphicsController.SetQualityLevel((byte)qualityIndex);
    }

    public void SetFullScreen(bool isFullSccreen)
    {
        SceneGraphicsController.SetFullscreen(isFullSccreen);
    }

    public void SetBrigthness(float brightness)
    {
        SceneGraphicsController.SetBrightness(brightness);
        brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightness * 100));
    }

    public void Back()
    {
        SetGraphicsSettingsValues();
        SceneGraphicsController.ApplyGraphicsSettings(GraphicsManager.Instance.GraphicsData);
    }

    public void Apply()
    {
        GraphicsData data = new GraphicsData()
        {
            Brightness = brightnessSlider.value,
            Fullscreen = fullscreenToggle.isOn,
            QualityLevel = byte.Parse(qualityDropdown.value.ToString()),
            Resolution = GraphicsManager.GetResolutionByIndex(resolutionDropdown.value)
        };
        GraphicsManager.Instance.GraphicsData = data;
    }

    public void SetDefault()
    {
        GraphicsManager.SetDefaultGraphics();
        SetGraphicsSettingsValues();
    }

    private void SetGraphicsSettingsValues()
    {
        GraphicsData data = GraphicsManager.Instance.GraphicsData;
        brightnessSlider.value = data.Brightness;
        brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightnessSlider.value * 100));
        qualityDropdown.value = data.QualityLevel;
        fullscreenToggle.isOn = data.Fullscreen;
        
        Resolution currentResolution = GraphicsManager.GetCurrentResolution();
        List<TMP_Dropdown.OptionData> options = resolutionDropdown.options;
        int index = -1;
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].text == currentResolution.ToString())
                index = i;
        }

        if (index < 0)
            InitializeResolutionDropdown();
        else
            resolutionDropdown.value = index;
    }
}
