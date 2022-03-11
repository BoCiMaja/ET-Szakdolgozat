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
            FindObjectOfType<SoundManager>().Play("Climbing");
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * 2);
        }
        else
        {
            rb.gravityScale = 1f;
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
        if (collision.CompareTag("Wall")){

            isWall= false;
            isClimbing  = false;
            animator.SetBool("isClimbing", false);
            FindObjectOfType<SoundManager>().Pause("Climbing");
        }
    }

}
