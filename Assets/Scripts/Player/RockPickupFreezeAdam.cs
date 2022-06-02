using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPickupFreezeAdam : StateMachineBehaviour
{
    public PlayerMovement player;
    public PlayerActions actions;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
            player.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            player.Rigidbody2D.isKinematic = true;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    player.Rigidbody2D.constraints = RigidbodyConstraints2D.None;
    //    player.Rigidbody2D.isKinematic = false;
    //}
}
