using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossText : MonoBehaviour
{

    public Animator animator;
    public float dialogue;
    public Boss_Health bosshp;

    public void Start()
    {
        GameObject.Find("BossText").transform.localScale = new Vector3(0, 0, 0);
        dialogue = 9.5f;
        animator.SetInteger("Dialogue", ((int)dialogue));
    }


    public void Update()
    {
        CheckDialogue();
    }

    public void CheckDialogue()
    {
        if (bosshp.hurt)
        {
            GameObject.Find("BossText").transform.localScale = new Vector3(1, 1, 1);
            
            dialogue -= Time.deltaTime;

            animator.SetTrigger("Hurt");
        }
        if(dialogue <= 0)
        {
            GameObject.Find("BossText").transform.localScale = new Vector3(0, 0, 0);

        }

        //GameObject.Find("BossText").transform.localScale = new Vector3(0, 0, 0);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Rock"))
    //    {
    //        hurt = true;
    //        GetComponent<Animator>().SetTrigger("Hurt");
    //    }
    //}
}
