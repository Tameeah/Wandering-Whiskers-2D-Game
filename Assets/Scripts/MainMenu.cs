using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangesSceneWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(0.3f);  // Let sound finish
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
