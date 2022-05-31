using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int health = 20;
    public bool isInvulnerable = false;
    public GameObject deathEffect;
    public bool hurt;
    public PlayerMovement adam;

    private void Update()
    {
        TakeDamage();
    }
    public void TakeDamage()
    {
        if (isInvulnerable)
            return;

        if (health <= 10)
        {
            GetComponent<Animator>().SetBool("is2ndPhase", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
            health--;
            hurt = true;
            adam.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            adam.Rigidbody2D.isKinematic = true;
            SoundManager.GetInstance().Play("LilithDamage");
            GetComponent<Animator>().SetTrigger("Hurt");
        }
    }

}
