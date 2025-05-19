using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public void ChangesSceneWithDelay(string sceneName) => StartCoroutine(LoadSceneAfterDelay(sceneName));

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
