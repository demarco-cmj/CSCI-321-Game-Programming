using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTutorialTrigger : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            TutorialController.Instance.EndWaterTutorial();
        }
    }
}
