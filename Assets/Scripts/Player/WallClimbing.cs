using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbing : MonoBehaviour
{
    private float vertical;
    private float speed;
    public bool isWall;
    public bool isClimbing;
    public bool isStandingClimbing;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        vertical = Input.GetAxis("Wallclimb");
        if (isWall && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
  
            isClimbing = true;
            animator.SetBool("isClimbing",true);
            animator.SetBool("isStaticClimbing", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFloating", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
        else if (isWall && Mathf.Abs(vertical) > 0f && !Input.anyKey)
        {
            isClimbing = true;
            animator.SetBool("isStaticClimbing", true);
            animator.SetBool("isClimbing", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFloating", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * 2);
            //FindObjectOfType<SoundManager>().Play("Climbing");
        }
        else
        {
            rb.gravityScale = 1f;
            //FindObjectOfType<SoundManager>().Stop("Climbing");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall")){
            isWall = true;
        }
        if (collision.CompareTag("Ground"))
        {
            isWall = false;
            isClimbing = false;
            isStandingClimbing = false;
            animator.SetBool("isClimbing", false);
            animator.SetBool("isStaticClimbing", false);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
            isWall = false;
            isClimbing = false;
            isStandingClimbing = false;
            animator.SetBool("isClimbing", false);
            animator.SetBool("isStaticClimbing", false);
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    isWall = false;
    //    isClimbing = false;
    //    isStandingClimbing = false;
    //    animator.SetBool("isClimbing", false);
    //    animator.SetBool("isStaticClimbing", false);
    //}

}
