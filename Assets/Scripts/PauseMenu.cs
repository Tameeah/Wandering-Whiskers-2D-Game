using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

///Title: How to Create a PAUSE MENU in Unity ! | UI Design Tutorial
//Author:Murat
//Date: 10 April 2025
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}




