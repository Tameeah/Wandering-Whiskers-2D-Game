using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] DresserPieces[] dresserPieces;
    [SerializeField] GameObject winPanel;
    [SerializeField] AudioSource applauseSound;
    [SerializeField] AudioSource sadSound;

    private int correctPieces = 0;
    private bool level2Ended = false;

    void Start()
    {
        winPanel.SetActive(false);
    }

    public void PiecePlacedCorrectly()
    {
        correctPieces++;

        if (correctPieces == dresserPieces.Length && !level2Ended)
        {
            EndLevel2(true);
        }
    }

    public void PieceRemovedFromCorrect()
    {
        correctPieces--;
    }

    private void EndLevel2(bool won)
    {
        level2Ended = true;

        if (won)
        {
            winPanel.SetActive(true);
            applauseSound.Play();
        }
    }
}


