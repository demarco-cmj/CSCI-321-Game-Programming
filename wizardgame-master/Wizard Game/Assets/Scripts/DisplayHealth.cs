using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Text health;
    //public GameObject[] hearts;
    void Start()
    {
        health = GetComponent<Text>();
        //hearts = new GameObject[6];
    }

    // Update is called once per frame
    // public static void CheckHP()
    // {
    //     health.text = "Health: " + GameVariables.playerHealth;

    //     switch(GameVariables.playerHealth){
    //         case 0:
    //             for(int i = 1; i < 7; i++){
    //                     hearts[i].SetActive(false);
    //             }
    //             break;
    //         case 1:
    //             hearts[1].SetActive(true);
    //             for(int i = 1; i < 7; i++){
    //                 if(i != 1){
    //                     hearts[i].SetActive(false);
    //                 }
    //             }
    //             break;
    //         case 2:
    //             hearts[2].SetActive(true);
    //             for(int i = 1; i < 7; i++){
    //                 if(i != 2){
    //                     hearts[i].SetActive(false);
    //                 }
    //             }
    //             break;
    //         case 3:
    //             hearts[3].SetActive(true);
    //             for(int i = 1; i < 7; i++){
    //                 if(i != 3){
    //                     hearts[i].SetActive(false);
    //                 }
    //             }
    //             break;
    //         case 4:
    //             hearts[4].SetActive(true);
    //             for(int i = 1; i < 7; i++){
    //                 if(i != 4){
    //                     hearts[i].SetActive(false);
    //                 }
    //             }
    //             break;
    //         case 5:
    //             hearts[5].SetActive(true);
    //             for(int i = 1; i < 7; i++){
    //                 if(i != 5){
    //                     hearts[i].SetActive(false);
    //                 }
    //             }
    //             break;
    //         case 6:
    //             hearts[6].SetActive(true);
    //             for(int i = 1; i < 7; i++){
    //                 if(i != 6){
    //                     hearts[i].SetActive(false);
    //                 }
    //             }
    //             break;
    //     }
    // }
}
