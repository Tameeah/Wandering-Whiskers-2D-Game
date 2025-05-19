using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Title: Create A 2D Idle Clicker Game in Unity! Tutorial 2 | Objectives To Click
//Author:CubicRogue
//Date: 19 April 2025
//Code Version: 
//Availability: https://www.youtube.com/watch?v=7kh608CL4hY&list=PL0P4wU0t1XrUYMYTC2zhM71MgguxSXCmJ&index=14


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
    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        timer = maxTime;
        audioSource = GetComponent<AudioSource>();
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
        }
    }
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
