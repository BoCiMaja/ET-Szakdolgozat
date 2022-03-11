using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float JumpForce = 400f;

    public CharacterController2D controller;
    private Rigidbody2D Rigidbody2D;

    public float runSpeed;
    float horizontalMove = 0f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    private Vector3 velocity = Vector3.zero;

    bool run = false;
    bool walk = false;

    bool jump = false;
    private int extraJump;
    public int extraJumpValue;
    [SerializeField] private bool airControl = false;

    private bool floating;

    private bool m_FacingRight = true;

    public Animator animator;

    public ParticleSystem dust;

    private void Awake()
    {
        extraJump = extraJumpValue;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Rigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove =  Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Walk") && jump == false && walk == false)
        {
            animator.SetBool("isWalking", true);
            runSpeed = 10f;
            FindObjectOfType<SoundManager>().Stop("Running"); 
            FindObjectOfType<SoundManager>().Play("Walking");
        }
        else if (Input.GetButtonUp("Walk") || runSpeed == 0f){
            animator.SetBool("isWalking", false);
            FindObjectOfType<SoundManager>().Stop("Walking");
        }
        if (Input.GetButtonDown("Run") && Input.GetButton("Walk"))
        {
            animator.SetBool("isWalking", false);
            walk = false;
            runSpeed = 30f;
            FindObjectOfType<SoundManager>().Play("Running");
            FindObjectOfType<SoundManager>().Stop("Walking");

        }
        else if (Input.GetButtonUp("Run"))
        {
            run = false;
            FindObjectOfType<SoundManager>().Stop("Running");
            if(runSpeed > 0f && Input.GetButton("Walk"))
            {
                walk = true;
                animator.SetBool("isWalking", true);
                runSpeed = 10f;
                FindObjectOfType<SoundManager>().Play("Walking");
            }
        }

    }

    private void FixedUpdate()
    {
        Physics2D.gravity = new Vector2(0, -9.8f);
        floating = false;
        Move(horizontalMove * Time.fixedDeltaTime, jump);
        Turning();
        Floating();
    }

    public void OnLanding()
    {
        CreateDust();
        animator.SetBool("isJumping", false);
        animator.SetBool("jumpedAlready", false);
        animator.SetBool("isFloating", false);
        if (runSpeed > 0f && Input.GetButton("Walk"))
        {
            animator.SetBool("isWalking", true);
            runSpeed = 10f;
            FindObjectOfType<SoundManager>().Play("Walking");
        }
    }

    public void Move(float move, bool jump)
    {
        if (controller.m_Grounded && jump)
        {
            controller.m_Grounded = false;
            Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }

        if (controller.m_Grounded || airControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
            Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);
        }
    }


    private void Turning()
    {
        if (horizontalMove > 0 && !m_FacingRight)
        {
            CreateDust(); // PARTICLE WHEN TURNING
            Flip();
            //animator.SetBool("isTurning", true);
        }
        else if (horizontalMove < 0 && m_FacingRight)
        {
            CreateDust(); // PARTICLE WHEN TURNING
            Flip();
            //animator.SetBool("isTurning", false);
        }
    }

    public void Floating()
    {
        if (!controller.m_Grounded && Input.GetButton("Jump") && Rigidbody2D.velocity.y < 0f &&
            controller.wallClimbing.isWall == false && controller.wallClimbing.isClimbing == false) // floating, glide
        {
            Physics2D.gravity = new Vector2(0, -0.8f);
            jump = false;
            floating = true;
            FindObjectOfType<SoundManager>().Stop("Running"); // running hang hivás
            FindObjectOfType<SoundManager>().Stop("Walking"); // running hang hivás
            animator.SetBool("isJumping", false);
            animator.SetBool("isFloating", true);
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        animator.SetBool("isTurning", true);
    }

    void CreateDust()
    {
        dust.Play();
    }


}
