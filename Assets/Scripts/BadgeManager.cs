using System;
using UnityEngine;
using UnityEngine.UI;

public class BadgeManager : MonoBehaviour
{
    public Image badge1Icon;
    public Image badge2Icon;
    public GameObject completionPanel;
    public AudioSource audioSource;

    private bool level1Complete = false;
    private bool level2Complete = false;
    private bool completed = false;

    void Start()
    {
        badge1Icon.gameObject.SetActive(false);
        badge2Icon.gameObject.SetActive(false);
        completionPanel.SetActive(false);
    }

    public void CompleteLevel(int level)
    {
        if (level == 1 && !level1Complete)
        {
            level1Complete = true;
            badge1Icon.gameObject.SetActive(true);
        }
        else if (level == 2 && !level2Complete)
        {
            level2Complete = true;
            badge2Icon.gameObject.SetActive(true);
        }

        CheckCompletion();
    }

    void CheckCompletion()
    {
        if (level1Complete && level2Complete)
        {
            completed = true;
            completionPanel.SetActive(true);
            if (audioSource != null)
            {
                audioSource.Play();
            }
            Debug.Log("Bedroom fully explored!");
        }
    }

    internal void WinGame(int v) => throw new NotImplementedException();
}


