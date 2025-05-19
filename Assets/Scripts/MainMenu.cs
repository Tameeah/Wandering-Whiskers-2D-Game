using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Title: Create LEVEL MENU in Unity: UI Design & Level Locking/Unlocking System!
//Author:Murat
//Date: 10 April 2025
//Code Version: 
//Availability:https://www.youtube.com/watch?v=2XQsKNHk1vk&list=PL0P4wU0t1XrUYMYTC2zhM71MgguxSXCmJ&index=17


public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public void ChangesSceneWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.3f);  // Let sound finish
        SceneManager.LoadScene(sceneName);
        transitionAnim.SetTrigger("start");
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
