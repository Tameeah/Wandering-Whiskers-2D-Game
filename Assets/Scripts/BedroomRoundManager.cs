using UnityEngine;

//Title: BedroomRoundManager
//Author: ChatGPT
//Date: 19 May 2025
//Code Version: 
//Availability:

public class BedroomRoundManager : MonoBehaviour
{
    [SerializeField] RewardBar rewardBar;
    public GameObject completionPanel;

    private bool level1Complete = false;
    private bool level2Complete = false;

    public object Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        rewardBar.ResetRewards();
        completionPanel.SetActive(false);
    }

    public void CompleteLevel(int level)
    {
        if (level == 1 && !level1Complete)
        {
            level1Complete = true;
            rewardBar.UpdateRewardBar(1);
        }
        else if (level == 2 && !level2Complete)
        {
            level2Complete = true;
            rewardBar.UpdateRewardBar(2);
        }

        CheckRoundCompletion();
    }

    void CheckRoundCompletion()
    {
        if (level1Complete && level2Complete)
        {
            Debug.Log("Bedroom round complete!");
            completionPanel.SetActive(true);
        }
    }
}
