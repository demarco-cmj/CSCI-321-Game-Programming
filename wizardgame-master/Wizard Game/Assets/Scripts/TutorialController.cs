using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public static TutorialController Instance;

    public Canvas UICanvas;
    public GameObject ObjectivesHint;
    public GameObject MoveTutorial;
    public GameObject MoveTutorialTrigger; 
    public GameObject JumpTutorial;
    public GameObject JumpTutorialTrigger;
    public GameObject WaterTutorial;
    public GameObject WaterTutorialTrigger;
    public GameObject CombatTutorial;

    // private GameObject currentTutorial;

    void Awake() {
        Instance = this;
    }

    void Start() {
        ObjectivesHint.SetActive(true);
    }

    void Update() {
        if (Input.GetButtonDown("ToggleUI")){
            ObjectivesHint.SetActive(false);
            
            if (MoveTutorial) {
                MoveTutorial.SetActive(true);
            }
        }
    }

    public void EndMoveTutorial() {
        if (MoveTutorial) {
            Destroy(MoveTutorial);
            Destroy(MoveTutorialTrigger);
            JumpTutorial.SetActive(true);
        }
    }

    public void EndJumpTutorial() {
        if (JumpTutorial) {
            Destroy(JumpTutorial);
            Destroy(JumpTutorialTrigger);
            WaterTutorial.SetActive(true);
        }
    }

    public void EndWaterTutorial() {
        if (WaterTutorial) {
            Destroy(WaterTutorial);
            CombatTutorial.SetActive(true);
        } 
    }

    public void EndCombatTutorial() {
        if(CombatTutorial) {
            Destroy(CombatTutorial);
        }
    }
}