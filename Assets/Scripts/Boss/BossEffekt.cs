using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffekt : MonoBehaviour
{

    public Animator animator;
    public Boss_Health bosshp;
    public int lifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HitEffekt").transform.localScale = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
    }

    public void CheckHit()
    {
        if (bosshp.hurt)
        {
            GameObject.Find("HitEffekt").transform.localScale = new Vector3(1, 1, 1);
            animator.SetTrigger("Boom");
            Destroy(GameObject.Find("HitEffekt"), lifeTime);
        }

        //GameObject.Find("BossText").transform.localScale = new Vector3(0, 0, 0);
    }
}
