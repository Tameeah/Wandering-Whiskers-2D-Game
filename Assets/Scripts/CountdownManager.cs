using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

//Title: CountdownManager
//Author: ChatGPT
//Date: 14 May 2025
//Code Version: 
//Availability:


public class CountdownManager : MonoBehaviour
{
    public static CountdownManager Instance;
    [SerializeField] TMP_Text countdownText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] float duration, currentTime;


    public float countdownTime = 15f;
    private bool isFirstCountdownDone = false;
    private bool isSecondCountdownStarted = false;

    public CountdownManager(bool isSecondCountdownStarted)
    {
        this.isSecondCountdownStarted = isSecondCountdownStarted;
    }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentTime = duration;
        timerText.text = currentTime.ToString();
        StartCoroutine(CountdownSequence());
    }

    private IEnumerator CountdownSequence()
    {
        while (countdownTime > 0)
        {
            countdownText.text = Mathf.Ceil(countdownTime).ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.text = "";

        isFirstCountdownDone = true;
        StartCoroutine(SecondCountdown());
    }

    private IEnumerator SecondCountdown()
    {
        isSecondCountdownStarted = true;

        while (currentTime >=0)
        {
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        countdownText.text = "";
    }
}

