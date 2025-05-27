using UnityEngine;
using System.Collections.Generic;

public class PanelChange : MonoBehaviour
{
    public List<GameObject> panels; // Assign in Inspector
    private int currentIndex = 0;

    void Start()
    {
        ShowPanel(currentIndex);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            NextPanel();
        }
        else if (Input.GetMouseButtonDown(1)) // Right Click
        {
            PreviousPanel();
        }
    }

    void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(i == index);
        }
    }

    void NextPanel()
    {
        currentIndex++;
        if (currentIndex >= panels.Count)
            currentIndex = 0;
        ShowPanel(currentIndex);
    }

    void PreviousPanel()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = panels.Count - 1;
        ShowPanel(currentIndex);
    }
}


