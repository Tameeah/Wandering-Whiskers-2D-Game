using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Title: Create LEVEL MENU in Unity: UI Design & Level Locking/Unlocking System!
//Author:Murat
//Date: 10 April 2025

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public string nextScene;
    public string previousScene;

    public KeyCode prevScnKey ;
    public KeyCode nextScnKey;

    [SerializeField] Animator transitionAnim;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            StartCoroutine(LoadSceneAfterDelay(sceneName));

        if (Input.GetKey(prevScnKey))
        {
            //Call Previous scene function here
            StartCoroutine(LoadSceneAfterDelay(previousScene)); 

        }
        if (Input.GetKey(nextScnKey))
        {
            //Call Previous scene function here
            StartCoroutine(LoadSceneAfterDelay(nextScene));

        }
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

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }
}
