using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem


public class BossTextFreeze : StateMachineBehaviour
{
    public GameObject gameObject;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //InputSystem
        gameObject.SetActive(true);
        //GameObject.Find("Adam_Basic(Clone)").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //GameObject.Find("Adam_Basic(Clone)").SetActive(false);
        //GameObject.Find("Adam_Basic(Clone)").GetComponent<Rigidbody2D>().isKinematic = true;
        // gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        // gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        SoundManager.GetInstance().Play("LilithTyping");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    GameObject.Find("Adam_Basic(Clone)").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    //    GameObject.Find("Adam_Basic(Clone)").GetComponent<Rigidbody2D>().isKinematic = false;
    //    //player.Rigidbody2D.constraints = RigidbodyConstraints2D.None;
    //    //player.Rigidbody2D.isKinematic = false;
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
