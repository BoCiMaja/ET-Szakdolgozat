using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public enum AudioTypes { master, effects, music};
    public AudioTypes audioType;

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range (.1f, 3f)]
    public float pitch;
    public float spatialBlend;
    public bool loop;
    public bool playOnAwake;
    [HideInInspector] //hide it in the inspector, despite it's public
    public AudioSource source;


}
