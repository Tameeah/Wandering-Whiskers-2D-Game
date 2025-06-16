using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelChange : MonoBehaviour
{
    public GameObject narrativePanel;

    public void Next()
    {
        narrativePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Exit(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }


    public void Back()
    {
        narrativePanel.SetActive(true);
        Time.timeScale = 1;
    }

}





