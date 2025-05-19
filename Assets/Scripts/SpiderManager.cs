using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpiderManager : MonoBehaviour
{
    public static SpiderManager instance;
    
    public GameObject winPanel;
    public GameObject losePanel;
    public AudioClip winSound;
    public AudioClip loseSound;
    public float maxTime = 20f;

    private int totalSpiders = 3;
    private int spidersDestroyed = 0;
    private AudioSource audioSource;
    private float timer;
    private bool level1Ended = false;
    private BedroomRoundManager bedroomRoundManager;
    
    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        timer = maxTime;
        audioSource = GetComponent<AudioSource>();
        bedroomRoundManager = FindAnyObjectByType<BedroomRoundManager>();
    }

    void Update()
    {
        if (level1Ended) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            LoseGame();
        }
    }
    
    public void SpidersDestroyed()
    {
        spidersDestroyed++;

        if(spidersDestroyed >= totalSpiders)
        {
            WinGame();
            OnLevel1Complete();
        }
    }

    public void OnLevel1Complete() => bedroomRoundManager.CompleteLevel(1);

    private void WinGame()
    {
        level1Ended = true;
        winPanel.SetActive(true);
        audioSource.PlayOneShot(winSound); 
        Debug.Log("Level 1 Complete!");
  
    }

    private void LoseGame()
    {
        level1Ended = true;
        losePanel.SetActive(true);
        audioSource.PlayOneShot(loseSound);
        Debug.Log("Level 1 Failed.");
    }

}
