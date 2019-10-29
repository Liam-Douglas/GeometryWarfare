using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Liam Nolan
// Controls the MainMenu functionality

public class MainMenu : MonoBehaviour
{
    // loads next scene in the scene load order
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits game when pressed
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
