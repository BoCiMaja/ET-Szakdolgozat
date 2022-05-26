using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfight_End : StateMachineBehaviour
{
    public int lifeTime = 10;
    public GameObject gameObject;
    public Animator animator;
    public float dialogue;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(GameObject.Find("BossText"), lifeTime);
        dialogue = 10;
        animator.SetInteger("Dialogue", ((int)dialogue));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dialogue -= Time.deltaTime;
        animator.SetInteger("Dialogue", ((int)dialogue));
    }
}