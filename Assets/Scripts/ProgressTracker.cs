using UnityEngine;
using UnityEngine.UI;

//Title:ProgressTracker 
//Author: ChatGPT
//Date: 19 May 2025
public class ProgressTracker : MonoBehaviour
{
    public static ProgressTracker Instance;

    public bool level1Complete = false;
    public bool level2Complete = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}