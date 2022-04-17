using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public Sound[] sounds;

    public static SoundManager instance;

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup effectsMixerGroup;
    [SerializeField] private AudioMixerGroup masterMixerGroup;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.spatialBlend = s.spatialBlend;
            s.source.playOnAwake = s.playOnAwake;

            switch (s.audioType)
            {
                case Sound.AudioTypes.master:
                    s.source.outputAudioMixerGroup = masterMixerGroup;
                    break;
                case Sound.AudioTypes.effects:
                    s.source.outputAudioMixerGroup = effectsMixerGroup;
                    break;
                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
    }

    public static SoundManager GetInstance()
    {
        return instance;
    }

    public void Start()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            Play("BGM");
        }
    }

    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Pause();
    }

    public void UpdateMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        masterMixerGroup.audioMixer.SetFloat("Master Volume", Mathf.Log10(AudioOptionsManager.masterVolume) * 20);
        effectsMixerGroup.audioMixer.SetFloat("Effects Volume", Mathf.Log10(AudioOptionsManager.effectsVolume) * 20);
    }

    //public void StopPlaying(string sound) // for stopping the BGM or Floating f.e.
    //{
    //    Sound s = Array.Find(sounds, item => item.name == sound);
    //    if (s == null)
    //    {
    //        Debug.LogWarning("Sound: " + name + " not found!");
    //        return;
    //    }

    //    s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
    //    s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

    //    s.source.Stop();
    //}

}
