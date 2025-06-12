using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

//Title: Create A 2D Idle Clicker Game in Unity! Tutorial 2 | Objectives To Click
//Author:CubicRogue
//Date: 19 April 2025

public class SpiderManager : MonoBehaviour
{
    public static SpiderManager instance; 
    
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject badgePanel;
    public AudioClip winSound;
    public AudioClip loseSound;
    public float maxTime = 20f;

    private int totalSpiders = 3;
    private int spiderKilled = 0;

    private AudioSource audioSource;
    private float timer;
    private bool level1Ended = false;

    public ParticleSystem LHSParticles;
    public ParticleSystem RHSParticles;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        timer = maxTime;
        audioSource = GetComponent<AudioSource>();
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        badgePanel.SetActive(false);
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
    
    public void SpiderKilled()
    {
        spiderKilled++;

        if(spiderKilled >= totalSpiders)
        {
            WinGame();
        }
    }
    private void WinGame()
    {
        level1Ended = true;

        if (LHSParticles != null)
        {
            LHSParticles.Play();
        }

        if (RHSParticles != null)
        {
            RHSParticles.Play();
        }

        winPanel.SetActive(true);
        audioSource.PlayOneShot(winSound); 
        Debug.Log("Level 1 Complete!");

        ProgressTracker.Instance.level1Complete = true;

        //StartCoroutine(ReturnToBedroom());
    }

    //private IEnumerator ReturnToBedroom()
    //{
        //yield return new WaitForSeconds(2f); // Let effects/sound play
        //UnityEngine.SceneManagement.SceneManager.LoadScene("BedroomScene");
    //}
    private void LoseGame()
    {
        level1Ended = true;
        losePanel.SetActive(true);
        audioSource.PlayOneShot(loseSound);
        Debug.Log("Level 1 Failed.");
    }

    public void Next()
    {
        badgePanel.SetActive(true);
        winPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
