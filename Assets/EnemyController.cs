using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject playertarget;
    private Vector3 direction;
    static Animator anim;

    public int enemyhealth = 100;
    public static EnemyController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            direction = playertarget.transform.position - this.transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.03f);
        }
    }

    public void EnemyReact()
    {
        enemyhealth -= 10;

        if (enemyhealth <= 0)
        {
            Knockout();
        }

        else
        {
            anim.SetTrigger("React");
            anim.ResetTrigger("Idle");
        }
    }

    public void Knockout()
    {
        anim.SetTrigger("Knockout");
    }
}
