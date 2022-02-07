using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController2D controller;

    public float runSpeed;

    float horizontalMove = 0f;

    bool jump = false;

    bool crouch = false;

    bool walk = false;

    public Animator animator;

    public ParticleSystem dust;

    // Update is called once per frame
    void Update()
    {
        horizontalMove =  Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Run")
            && walk != true)
        {
            FindObjectOfType<SoundManager>().Stop("Walking"); 
            FindObjectOfType<SoundManager>().Play("Running"); // running hang hivás
        }
        else if (Input.GetButtonUp("Run") || runSpeed == 0f){
            FindObjectOfType<SoundManager>().Stop("Running"); // running hang hivás
        }
        if (Input.GetButtonDown("Walk") || Input.GetKeyDown(KeyCode.LeftShift))
        {
            walk = true;
            runSpeed = 20f;
            FindObjectOfType<SoundManager>().Play("Walking"); //walk hang hivas
            FindObjectOfType<SoundManager>().Stop("Running");

        }
        else if (Input.GetButtonUp("Walk") || Input.GetKeyUp(KeyCode.LeftShift))
        {
            walk = false;
            runSpeed = 30f;
            FindObjectOfType<SoundManager>().Stop("Walking");
        }

    }

    private void FixedUpdate()
    {
        jump = false;
        // MOVE
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, walk);
    }

    public void OnLanding()
    {
        CreateDust();
        animator.SetBool("isJumping", false);
        animator.SetBool("jumpedAlready", false);
        animator.SetBool("isFloating", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
        FindObjectOfType<SoundManager>().Play("Crouching"); //crouch hang hivas
    }

    public void OnWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }


    void CreateDust()
    {
        dust.Play();
    }


}
