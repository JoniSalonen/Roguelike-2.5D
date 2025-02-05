using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    // Canvas objects
    public Canvas stats;
    public Canvas pauseMenu;

    private bool isPaused;


    void Start()
    {
        // Get the Canvas objects
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        stats = stats.GetComponent<Canvas>();
        // Pause Check
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Shows Pause Menu when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            // Show Pause Menu
            pauseMenu.enabled = true;
            stats.enabled = false;
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            // Hide Pause Menu
            isPaused = false;
            Time.timeScale = 1;
            pauseMenu.enabled = false;
        }

    }





}
