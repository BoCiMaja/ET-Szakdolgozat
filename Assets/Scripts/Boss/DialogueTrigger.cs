using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour

    
{
    public Animator textanimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("BossText").transform.localScale = new Vector3(1, 1, 1);
            textanimator.SetTrigger("Collider");


        }
    }
}
