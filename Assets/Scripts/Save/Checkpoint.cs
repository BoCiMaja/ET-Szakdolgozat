using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //CheckpointMaster.GetInstance().SetCheckpointPlayerPosition(transform);

            GameSession.SaveAtPosition(this.transform.position);
        }
    }
}
