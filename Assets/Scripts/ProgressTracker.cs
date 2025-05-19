using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour
{
    public Slider progressBar; // Attach the UI Slider here
    public GameObject completionPanel; // Attach the completion panel here

    private int progress = 0;
    private int maxProgress = 2;

    void Start()
    {
        progressBar.value = 0;
        completionPanel.SetActive(false);
    }

    public void CompleteLevel(int level)
    {
        // Prevent duplicate progress from same level
        if (level == 1 && progress < 1)
        {
            progress++;
        }
        else if (level == 2 && progress < 2)
        {
            progress++;
        }

        progressBar.value = progress;

        if (progress >= maxProgress)
        {
            Debug.Log("All levels complete!");
            completionPanel.SetActive(true);
        }
    }
}
