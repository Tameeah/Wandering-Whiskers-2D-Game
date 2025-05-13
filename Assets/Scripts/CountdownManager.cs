using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject timesUpPanel;
    [SerializeField] TMP_Text timerText;


    private float countdownTime = 3f;
    private bool isFirstCountdownDone = false;
    private bool isSecondCountdownStarted = false;
    private float secondCountdownTime = 15f;

    void Start()
    {
        timesUpPanel.SetActive(false);
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

        while (secondCountdownTime > 0)
        {
            timerText.text = Mathf.Ceil(secondCountdownTime).ToString();
            yield return new WaitForSeconds(1f);
            secondCountdownTime--;
        }

        countdownText.text = "";
        timesUpPanel.SetActive(true);
    }
}

