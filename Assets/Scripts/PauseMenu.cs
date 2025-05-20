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
    public string nextScene;
    public string previousScene;

    public KeyCode prevScnKey;
    public KeyCode nextScnKey;


    public void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;

        }
            
    }

    public void Play()
    {
        if (Input.GetKey(prevScnKey))
        { 
            pauseMenu.SetActive(false);
            Time.timeScale = 1;

        }

           
    }
    public void GoToScene(string sceneName)
    {
        if (Input.GetKey(prevScnKey))
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1;
    }

        }

            
}




