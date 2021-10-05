using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMenu : MonoBehaviour
{
    Text list;
    void Start()
    {
        list = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        list.text = "Goals:\n  -Red Gems:    " + GameVariables.redGems + "/4\n  -Blue Gems:    " + GameVariables.blueGems + "/4\n  -Yellow Gems: " + GameVariables.yellowGems + "/4";
    }
}
