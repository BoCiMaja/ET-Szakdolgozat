using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float begin;
    public float dist = 4;
    public float speed = 4;
    public int dir;
    public GameObject Adam;
    public CharacterController2D characterController;

    // Start is called before the first frame update
    void Start()
    {
        begin = transform.position.x;
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > begin + dist) { dir = -1; }
        else { if (transform.position.x < begin - dist) { dir = 1; } }

        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * dir,
                                          transform.position.y,
                                          transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (characterController.m_GroundCheck && !characterController.jump && collision.gameObject.tag == "Player")
        {
            Adam.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Adam.transform.parent = null;
    }

}
