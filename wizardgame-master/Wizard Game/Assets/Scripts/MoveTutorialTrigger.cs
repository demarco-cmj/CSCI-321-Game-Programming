using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorialTrigger : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            TutorialController.Instance.EndMoveTutorial();
        }
    }
}
