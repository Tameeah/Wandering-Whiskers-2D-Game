using UnityEngine;
using UnityEngine.SceneManagement;

///Title: How to Create a PAUSE MENU in Unity ! | UI Design Tutorial
//Author:Murat
//Date: 10 April 2025
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject roomsPanel;
    [SerializeField] GameObject movementPanel;

    [Header("Animations")]
    [SerializeField] Animator catAnimator;
    [SerializeField] Animator pawWaveAnimator;

    public void Pause()
    {
        pauseMenu.SetActive(true);

        if (catAnimator != null )
            catAnimator.Play("Tail Move", -1, 0f);

       if (pawWaveAnimator != null)
            pawWaveAnimator.Play("PawPrintsLeft", -1, 0f); 
     
        Time.timeScale = 0;
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
        movementPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }


    public void Levels()
    {
        roomsPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void Movement()
    {
        movementPanel.SetActive(true);
        Time.timeScale = 1;
    }
}

