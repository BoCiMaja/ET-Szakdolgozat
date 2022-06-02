using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStart : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.GetInstance().Play("FireStart");
        SoundManager.GetInstance().Play("FireLoop");
    }


}
