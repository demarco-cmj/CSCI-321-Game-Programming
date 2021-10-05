using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTreefall : MonoBehaviour
{
    private AudioSource SFX;
    public AudioClip pickup;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GameVariables.playerHealth < GameVariables.MAX_HP) {
    
            AudioSource SFX = gameObject.AddComponent<AudioSource>();
            SFX.clip = pickup;
            SFX.Play();
            Destroy(gameObject, 10);
        }
    }
}
