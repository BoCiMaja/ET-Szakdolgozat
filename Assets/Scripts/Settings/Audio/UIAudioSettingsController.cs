using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioSettingsController : MonoBehaviour, IUISettings
{
    //Menu elemek

    void Start()
    {
        if (AudioManager.Instance != null)
            InitializeDatas();
    }

    //Szépítés
    private void InitializeDatas()
    {
        AudioData data = AudioManager.Instance.AudioData;
        //brightnessSlider.value = data.Brightness;
        //brightnessText.text = string.Format("{0}%", Mathf.RoundToInt(brightnessSlider.value * 100));
        //qualityDropdown.value = data.QualityLevel;
        //fullscreenToggle.isOn = data.Fullscreen;
        //menu beállítása
        throw new System.NotImplementedException();
    }

    public void Apply()
    {
        throw new System.NotImplementedException();
    }

    public void Back()
    {
        throw new System.NotImplementedException();
    }

    public void SetDefault()
    {
        throw new System.NotImplementedException();
    }

    public void SetMasterVolume(float volume)
    {
        throw new System.NotImplementedException();
    }

    public void SetBgmVolume(float volume)
    {
        throw new System.NotImplementedException();
    }

    public void SetEffectVolume(float volume)
    {
        throw new System.NotImplementedException();
    }

    private void SetAudioSettingsValues()
    {
        throw new System.NotImplementedException();
    }
}
