using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public enum AudioTypes { effects, music};
    public AudioTypes audioType;

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range (.1f, 3f)]
    public float pitch;
    public bool loop;
    [HideInInspector] //hide it in the inspector, despite it's public
    public AudioSource source;


}
