using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        print("Collided");
        if (other.gameObject.tag == "Player") {
            print("Moving to main level");
            SceneManager.LoadScene("Main Level");
        }
    }
}
