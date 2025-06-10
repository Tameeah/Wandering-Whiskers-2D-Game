using UnityEngine;
using UnityEngine.SceneManagement;

///Title: How to Create a PAUSE MENU in Unity ! | UI Design Tutorial
//Author:Murat
//Date: 10 April 2025
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject roomsPanel;
    [SerializeField] Animator catAnimation;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        if (catAnimation != null)
        {
            catAnimation.Play("Idle");  
        }
    }

    public void Exit(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        roomsPanel.SetActive(false);
        Time.timeScale = 1;

        catAnimation.enabled = false;
    }

    public void Levels()
    {
        roomsPanel.SetActive(true);
        Time.timeScale = 1;
    }
}

