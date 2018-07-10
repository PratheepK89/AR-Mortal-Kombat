using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject EnemyTarget;

    public static bool walkForward;
    public static bool walkback;
    static Animator anim;
    private bool isAttacking;
    private Vector3 direction;
    public static PlayerScript instance;

    public int playerHealth = 100;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update () {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            isAttacking = false;
            direction = EnemyTarget.transform.position - this.transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.3f);
        }

        if (!isAttacking)
        {
            if (walkForward)
            {
                anim.SetTrigger("WalkForward");
                anim.ResetTrigger("Idle");
            }

            if (walkback)
            {
                anim.SetTrigger("WalkBack");
                anim.ResetTrigger("Idle");
            }
            else if (!walkback && !walkForward)
            {
                anim.SetTrigger("Idle");
                anim.ResetTrigger("WalkBack");
                anim.ResetTrigger("WalkForward");
            }
        }
    }

    public void Punch()
    {
        isAttacking = true;
        anim.ResetTrigger("Idle");
        anim.SetTrigger("Punch");
    }

    public void Kick()
    {
        isAttacking = true;
        anim.ResetTrigger("Idle");
        anim.SetTrigger("Kick");
    }

    public void React()
    {
        isAttacking = true;
        anim.ResetTrigger("Idle");
        anim.SetTrigger("React");
        playerHealth -= 10;
    }
}
