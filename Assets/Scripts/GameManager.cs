using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int caughtSpiders;

    public TextMeshProUGUI caughtText;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public void AddSpiders(int amount)
    {
        caughtSpiders += amount;
        caughtText.text = "Spiders Caught" + caughtSpiders.ToString();
    }

    public void RemoveSpiders(int amount)
    {
        caughtSpiders -= amount;
        caughtText.text = "Spiders Caught" + caughtSpiders.ToString();
    }

}
