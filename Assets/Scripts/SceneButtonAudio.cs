using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonAudio : MonoBehaviour
{
    public Button button;              
    public AudioSource audioSource;    
    public AudioClip clickSound;       
    public string nextSceneName;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        audioSource.PlayOneShot(clickSound);
        Invoke("LoadNextScene", 0.3f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
