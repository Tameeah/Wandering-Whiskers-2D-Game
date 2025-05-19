using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Title: LevelMenu
//Author: ChatGPT
//Date: 7 May 2025
public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
