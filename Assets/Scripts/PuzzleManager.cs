using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject winPanel;
    public GameObject losePanel;
    public AudioClip winSound;
    public AudioClip loseSound;
    public float maxTime = 20f;

    private int piecesPlaced = 0;
    private AudioSource audioSource;
    private float timer;
    private bool level2Ended = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        timer = maxTime;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (level2Ended) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            LoseGame();
        }
    }

    public void PiecePlaced()
    {
        piecesPlaced++;
        if (piecesPlaced >= 5)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        level2Ended = true;
        winPanel.SetActive(true);
        audioSource.PlayOneShot(winSound);
        Debug.Log("Level 2 Complete!");
        // Here you can trigger the next level logic
    }

    private void LoseGame()
    {
        level2Ended = true;
        losePanel.SetActive(true);
        audioSource.PlayOneShot(loseSound);
        Debug.Log("Level 2 Failed.");
    }
}




