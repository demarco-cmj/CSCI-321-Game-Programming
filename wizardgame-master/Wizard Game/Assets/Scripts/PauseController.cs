using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseCanvas;
    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            if (paused) {
                Time.timeScale = 1f;
                pauseCanvas.gameObject.SetActive(false);
                paused = false;
            } else {
                Time.timeScale = 0f;
                pauseCanvas.gameObject.SetActive(true);
                paused = true;
            }
        }
    }
}
