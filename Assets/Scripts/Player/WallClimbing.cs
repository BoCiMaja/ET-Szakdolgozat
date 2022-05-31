using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbing : MonoBehaviour
{
    private float vertical;
    private float speed;
    public bool isWall;
    public bool isClimbing;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        vertical = Input.GetAxis("Wallclimb");
        if (isWall && Mathf.Abs(vertical) > 0f)
        {
  
            isClimbing = true;
            animator.SetBool("isClimbing",true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFloating", false);
            animator.SetBool("isWalking", false);
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
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
            isWall = false;
            isClimbing = false;
            animator.SetBool("isClimbing", false);
    }

}
