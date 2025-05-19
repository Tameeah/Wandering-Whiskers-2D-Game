using UnityEngine;
using UnityEngine.UI;

//Title:RewardBar
//Author: ChatGPT
//Date: 19 May 2025
//Code Version: 
//Availability:

public class RewardBar : MonoBehaviour
{
    public Image reward1Image;
    public Image reward2Image;
    public Sprite earnedSprite;
    public Sprite lockedSprite;

    public void ResetRewards()
    {
        reward1Image.sprite = lockedSprite;
        reward2Image.sprite = lockedSprite;
    }

    public void UpdateRewardBar(int rewardNumber)
    {
        if (rewardNumber == 1)
            reward1Image.sprite = earnedSprite;
        else if (rewardNumber == 2)
            reward2Image.sprite = earnedSprite;
    }
}
