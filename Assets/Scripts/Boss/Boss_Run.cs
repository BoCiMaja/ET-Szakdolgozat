using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float speed = 1;
    public float attackRange = 3f;
    public Vector3 offset;
    public Vector3 direction;
    public Vector3 adjustedThrow;

    public int lifeTime = 5;
    public GameObject gameObject;


    Transform player;
    GameObject player2;
    Rigidbody2D rb;
    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player =  GameObject.FindGameObjectWithTag("Player").transform;

        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();

        adjustedThrow = direction;
        rb.AddForce(adjustedThrow * speed, ForceMode2D.Impulse);
        boss.transform.Translate(offset);
        Destroy(GameObject.Find("Boss"), lifeTime);
        SoundManager.GetInstance().Play("LilithWalk");
    }

    public void MoveInALine()
    {
        boss.transform.position += direction * this.speed * Time.deltaTime;
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * speed;
        //rb.MovePosition(gameObject.transform.position + speed * Time.deltaTime * direction);

        MoveInALine();
        

        //boss.LookAtPlayer();

        //Vector2 targetPlayer = new Vector2(player.position.x, rb.position.y);
        //Vector2 newBossPos =  Vector2.MoveTowards(rb.position*-1, targetPlayer, speed * Time.fixedDeltaTime);
        //rb.MovePosition(newBossPos);

        //if(Vector2.Distance(player.position, rb.position)<= attackRange) {
        //    animator.SetTrigger("Attack");
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.ResetTrigger("Attack");
    //}


}
