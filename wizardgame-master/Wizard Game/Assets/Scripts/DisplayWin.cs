using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWin : MonoBehaviour
{
    Text list;
    void Start()
    {
        list = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int minutes = (int) GameVariables.timeElapsed / 60;
        int seconds = (int) GameVariables.timeElapsed % 60;
        int score = 10000 - (3 * (int) GameVariables.timeElapsed) + (1000 * GameVariables.beesKilled);
        list.text = "You Win!\n  -Deaths:       " + GameVariables.deaths + "\n  -Bees Killed:   " + GameVariables.beesKilled 
            + "\n  -Time Elapsed: " + minutes + ":" + seconds + "\n\nScore:     " + score + "pts";
    }
}
