using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorialTrigger : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other) {
        print("Ending Jump Tutorial");
        if (other.gameObject.CompareTag("Player")) {
            TutorialController.Instance.EndJumpTutorial();
        }
    }
}
