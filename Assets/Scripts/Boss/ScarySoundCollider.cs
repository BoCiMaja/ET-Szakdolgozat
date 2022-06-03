using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarySoundCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.GetInstance().Play("ScarySound");

        }
    }
}
