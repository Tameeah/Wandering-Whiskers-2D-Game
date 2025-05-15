using UnityEngine;

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

    public void PiecesPlaced()
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
        UIManager.Instance.ShowWinPanel(); // Show win UI
    }

    public void Level2Failed()
    {
        if (!level2Ended)
        {
            level2Ended = true;
            Debug.Log("Level Failed! Not all spiders were caught.");
        }
    }
}
