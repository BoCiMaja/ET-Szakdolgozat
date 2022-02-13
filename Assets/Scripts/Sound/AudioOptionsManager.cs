using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    public static float effectsVolume { get; private set;}
    public static float masterVolume { get; private set; }

    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI effectsSliderText;
    [SerializeField] private TextMeshProUGUI masterSliderText;

    public void OnMasterSliderValueChange(float value)
    {
        masterVolume = value;
        masterSliderText.text = ((int)(value * 100)).ToString();
        SoundManager.instance.UpdateMixerVolume();
    }
    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        musicSliderText.text = ((int)(value * 100)).ToString();
        SoundManager.instance.UpdateMixerVolume();
    }
    public void OnEffectsSliderValueChange(float value)
    {
        effectsVolume = value;
        effectsSliderText.text = ((int)(value*100)).ToString();
        SoundManager.instance.UpdateMixerVolume();
    }
}
