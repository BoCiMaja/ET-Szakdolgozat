using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heaven4Controller : MonoBehaviour
{
    private void Start()
    {
        SoundManager.GetInstance().Play("Labor3BGM");
        //SoundManager.GetInstance().Stop("Ambient");
        SoundManager.GetInstance().Stop("Labor2BGM");

    }

    private void Update()
    {
        if (GameObject.Find("Boss") == false)
        {
            SoundManager.GetInstance().Stop("LilithWalk");
            GameObject.Find("Adam_Basic(Clone)").GetComponent<Rigidbody2D>().isKinematic = false;
            GameObject.Find("Adam_Basic(Clone)").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}
