using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{

    private AudioSource SFX;
    public AudioClip pickup;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            if(this.gameObject.tag == "Red Gem"){
                GameVariables.redGems += 1;
            }
            else if(this.gameObject.tag == "Yellow Gem"){
                GameVariables.yellowGems += 1;
            }
            else if(this.gameObject.tag == "Blue Gem"){
                GameVariables.blueGems += 1;
            }
            AudioSource SFX = gameObject.AddComponent<AudioSource>();
            SFX.clip = pickup;
            SFX.Play();

            Destroy(gameObject, (float) 0.5);
            print("Player collencted gem");
        }
    }
}
