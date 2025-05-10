using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool isLevel1Complete = false;
    
    public void CompleteLevel1()
    {
        isLevel1Complete=true;

        PlayerPrefs.SetInt("Level1Complete", 1);
        PlayerPrefs.Save();
    }
    public void PlayLevel2()
    {
        isLevel1Complete = PlayerPrefs.GetInt("Level1Complete", 0) == 1;

        if (isLevel1Complete )
        {
            Debug.Log("Loading Level 2...");
            SceneManager.LoadScene("Level2");
        }
        else
        {
            Debug.Log("You must complete Level 1 first!");
        }
    }

}
