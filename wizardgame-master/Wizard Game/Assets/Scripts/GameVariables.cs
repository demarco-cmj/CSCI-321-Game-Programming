using System.Collections;
using UnityEngine;

public static class GameVariables
{
    public static int MAX_HP = 6;
    public static int playerHealth = 6; //Starting health and current health
    public static int deaths = 0;
    public static int redGems = 0;
    public static int blueGems = 0;
    public static int yellowGems = 0;
    public static bool toggleMenu = false;
    public static bool checkpoint = false;
    public static float timeElapsed = 0.0f;
    public static int beesKilled = 0;



    // public static void Injure(int x) {
    //     //print("Hurt player by " + x);
    // }
}
