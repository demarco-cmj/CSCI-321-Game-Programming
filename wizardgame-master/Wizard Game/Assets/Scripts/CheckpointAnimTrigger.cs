using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnimTrigger : MonoBehaviour
{
    public Animator myAnimationController;
    

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) {
            myAnimationController.SetBool("CheckpointBool", true);
        }
    }
}
