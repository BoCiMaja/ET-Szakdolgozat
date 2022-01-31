using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;


    private void Update()
    {
        RockTrajectory();
    }

    public void RockTrajectory()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall") || collision.CompareTag("Ground")
            || collision.CompareTag("NoClimbWall"))
        {
            if (this.destroyed != null)
            {
                this.destroyed.Invoke(); // tudatjuk / küldünk jelet, hogy destroyolva van az object
            }
            Destroy(this.gameObject);
        }
    }
}
