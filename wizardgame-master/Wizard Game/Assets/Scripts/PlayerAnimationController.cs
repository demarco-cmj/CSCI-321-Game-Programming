using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    private GameObject player;
    private float landDist = 5f;

    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Wizard");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Spacebar");
            anim.SetBool("Grounded", false);
        }

        if (anim.GetBool("Grounded") == false)
        {
            ray = new Ray(player.transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < landDist)
                {
                    anim.SetBool("Landing", true);
                }
            }
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        anim.ResetTrigger("Spacebar");
        anim.SetBool("Grounded", true);
        anim.SetBool("Landing", false);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
