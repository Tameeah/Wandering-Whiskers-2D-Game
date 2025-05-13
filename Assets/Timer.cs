using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    [SerializeField] GameObject TimesUpScreen;
    [SerializeField] TextMeshProUGUI timeText; 
    [SerializeField] float duration, currentTime;
    internal static Timer instance;

    void Start()
    {
        TimesUpScreen.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    private void start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = " ";

        Timer.instance.BeginTime();

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }


    IEnumerator TimeIEn()
    {
        while (currentTime >=0)
        {
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        timeText.text = "";
        TimesUpScreen.SetActive(true);
    }

    internal void BeginTime()
    {
        throw new NotImplementedException();
    }
}
