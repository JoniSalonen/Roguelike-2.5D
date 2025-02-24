using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string mainMenu; // The name of the main menu scene
    public string levelSelect; // The name of the level select scene

    public void GoToMainMenu()
    {
        Time.timeScale = 1; // Set the time scale to 1 (normal speed)
        SceneManager.LoadScene(mainMenu); // Load the main menu scene
    }

    public void GoToLevelSelect()
    {
        Time.timeScale = 1; // Set the time scale to 1 (normal speed)
        SceneManager.LoadScene(levelSelect); // Load the level select scene
    }

    public void OnApplicationQuit()
    {
        Application.Quit(); // Quit the application
    }
}

