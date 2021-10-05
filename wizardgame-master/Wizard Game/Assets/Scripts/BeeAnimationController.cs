using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeAnimationController : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Attack() 
    {
        anim.SetTrigger("Attack");
    }
    public void Die() 
    {
        anim.SetTrigger("Dead");
    }
}
