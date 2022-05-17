using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_float : MonoBehaviour
{
    public PlayerMovement controller;
    public Animator animator;

    public GameObject gameObject;
    public void Start()
    {
        GameObject.Find("Umbrella").transform.localScale = new Vector3(0, 0, 0);
    }

    public void Update()
    {
        CheckFloat();
    }

    public void CheckFloat()
    {
        if (controller.floating == true) {
            animator.SetBool("isFloating", true);
            GameObject.Find("Umbrella").transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            animator.SetBool("isFloating", false);
            GameObject.Find("Umbrella").transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
