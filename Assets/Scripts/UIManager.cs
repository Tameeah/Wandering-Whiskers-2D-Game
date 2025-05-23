using UnityEngine;

//Title:UIManager
//Author: ChatGPT
//Date: 17 May 2025
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject winPanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
}


