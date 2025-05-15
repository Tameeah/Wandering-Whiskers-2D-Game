using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    private int totalPieces = 5;
    private int piecesPlaced = 0;
    private bool level2Ended = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void PiecesPlacedCorrectly()
    {
        piecesPlaced++;

        if (piecesPlaced >= totalPieces)
        {
            Level2Complete();
        }
    }
    void Level2Complete()
    {
        level2Ended = true;
        Debug.Log("Level Complete! You earned a reward!");
        UIManager.Instance.ShowWinPanel(); 
    }

    public void Level2Failed()
    {
        if (!level2Ended)
        {
            level2Ended = true;
            Debug.Log("Level Failed! Not all pieces were placed.");
        }
    }
}
