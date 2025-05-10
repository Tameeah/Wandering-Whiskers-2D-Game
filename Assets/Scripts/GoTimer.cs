using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GoTimer : MonoBehaviour
{
    public int countdownTime;
    public Text countdownText;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownText.text = "GO!";

        Timer.instance.BeginTime();

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }
}
    
