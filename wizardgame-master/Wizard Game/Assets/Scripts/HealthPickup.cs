using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    private AudioSource SFX;
    public AudioClip pickup;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GameVariables.playerHealth < GameVariables.MAX_HP) {
            GameVariables.playerHealth += 1;
            AudioSource SFX = gameObject.AddComponent<AudioSource>();
            SFX.clip = pickup;
            SFX.Play();

            Destroy(gameObject, (float) 0.5);
            print("Player health increased");
        }
    }
}
