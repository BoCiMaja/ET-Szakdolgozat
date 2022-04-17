using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Idle_1 : StateMachineBehaviour
{
    public float randomNumber;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomNumber = Random.Range(0, 10);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (randomNumber >= 5)
        {
            animator.SetTrigger("Jump");
        }
        else
        {
            animator.SetTrigger("Shoot");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Jump");
        animator.ResetTrigger("Shoot");
    }
}
