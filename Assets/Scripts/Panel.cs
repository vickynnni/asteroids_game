using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject PausePanel; // Reference to your panel GameObject

    void Start()
    {
        PausePanel.SetActive(false); // To hide the panel at the start of the game
    }
    void Update()
    {
    }

    public void Pause() {
        PausePanel.SetActive(true); // To show the panel
        Time.timeScale = 0; // To freeze the time
    }

    public void Continue() {
        PausePanel.SetActive(false); // To hide the panel
        Time.timeScale = 1; // To unfreeze the time
    }
}
