using UnityEngine;

//Title: BedroomRoundManager
//Author: ChatGPT
//Date: 19 May 2025

public class BedroomRoundManager : MonoBehaviour
{
    [SerializeField] private GameObject reward1Image;
    [SerializeField] private GameObject reward2Image;
    public GameObject completionPanel;
    public GameObject nextButton;

    void Start()
    {
        // Show rewards
        reward1Image.SetActive(ProgressTracker.Instance.level1Complete);
        reward2Image.SetActive(ProgressTracker.Instance.level2Complete);

        completionPanel.SetActive(false);
        nextButton.SetActive(false);

        // Check for round completion
        if (ProgressTracker.Instance.level1Complete && ProgressTracker.Instance.level2Complete)
        {
            nextButton.SetActive(true);
        }
    }

    public void OnNextButtonClicked()
    {
        nextButton?.SetActive(false);
        completionPanel?.SetActive(true);
    }
}


