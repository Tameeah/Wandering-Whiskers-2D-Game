using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject winPanel;
    public GameObject failPanel;

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


