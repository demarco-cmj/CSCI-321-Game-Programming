using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeController : MonoBehaviour
{
    public Transform[] points;
 
    private NavMeshAgent agent;
    private int destpoint = 0;
    private Rigidbody rb;
    private CapsuleCollider beeCollider;
    private BeeAnimationController animController;

    private Ray ray;
    private RaycastHit hit;
    public float sightDistance = 12f;
    public float damageDistance = 100f;
    public float aggroDistance = 800f;

    public GameObject player;
    private bool attacking = false; //changed
    private float timeToAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animController = GetComponent<BeeAnimationController>();
        beeCollider = GetComponent<CapsuleCollider>();

        agent.autoBraking = false; //might change not sure
        GotoNextPoint();
    }

    void FixedUpdate() 
    {
        // print("Attacking: " + attacking);
    }

    // Update is called once per frame
    void Update()
    {
        timeToAttack -= Time.deltaTime;
        ray = new Ray(transform.position + new Vector3(0f, beeCollider.center.y + 4f, 0f), transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * damageDistance, Color.blue);
        switch (attacking)
        {
            case false:
                
                if (!agent.pathPending && agent.remainingDistance < 0.2f && !attacking)
                {
                    GotoNextPoint();
                }

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Player") && hit.distance < sightDistance)
                    {
                        //move towards the player
                        agent.destination = hit.transform.position;
                        attacking = true;
                    }
                }
                break;
            case true:
                if (timeToAttack <= 0f)
                {
                    agent.destination = player.transform.position;
                    print("Here 1");

                    if (Physics.Raycast(ray, out hit)) 
                    {
                        print("here 2");
                        print("dist: " + hit.distance);

                        if (hit.collider.CompareTag("Player") && hit.distance < damageDistance * 5) 
                        {
                            
                            GameVariables.playerHealth -= 1; //damage player
                            animController.Attack(); //play attack animation
                            print("Hit");
                            timeToAttack = 2f;
                        }
                    }

                }
                else
                {
                    agent.destination = player.transform.position;
                    break;
                }
                break;
        }
        
        
        
    }

    void GotoNextPoint() 
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destpoint].position;
        //agent.destination = point.position; //change

        destpoint = (destpoint + 1) % points.Length;
        //print(agent.destination.x + ", " + agent.destination.y + " " + agent.destination.z);
    }

    //plays death animation and despawns bee
    public void Die()
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        //bee death animation
        animController.Die();
        //wait for animation to be done
        yield return new WaitForSeconds(0.933f);
        //bee despawns
        gameObject.SetActive(false);

        if (TutorialController.Instance) {
            TutorialController.Instance.EndCombatTutorial();
        }

        Destroy(gameObject);
    }
}
