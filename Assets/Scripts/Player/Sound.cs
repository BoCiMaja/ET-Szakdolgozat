using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioSource jumpsound;
    public AudioSource glidesound;

    // Start is called before the first frame update
    void Start()
    {
        jumpsound = GetComponent<AudioSource>();
        glidesound = GetComponent<AudioSource>();
    }

    

    public void JumpSound()
    {
        jumpsound.Play();
    }

    public void GlideSound()
    {
       glidesound.Play();
    }

}
