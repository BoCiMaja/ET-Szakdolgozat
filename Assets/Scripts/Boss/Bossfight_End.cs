using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfight_End : StateMachineBehaviour
{
    public int lifeTime = 10;
    public GameObject gameObject;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(GameObject.Find("Boss"), lifeTime);
    }

}
