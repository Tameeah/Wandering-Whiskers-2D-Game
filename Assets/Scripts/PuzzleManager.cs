using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Title:PuzzleManager
//Author: ChatGPT
//Date: 17 May 2025

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject badgePanel;
    public AudioClip winSound;
    public AudioClip loseSound;
    public float maxTime = 30f;

    public int piecesPlaced = 0;
    private AudioSource audioSource;
    private float timer;
    private bool level2Ended = false;

    public GameObject puzzlePreview; 
    public float previewDuration = 5f; 
    public GameObject[] puzzlePieces;

    public ParticleSystem LHSParticles;
    public ParticleSystem RHSParticles;
    void Start()
    {
        //Instance = this;
        timer = maxTime;
        audioSource = GetComponent<AudioSource>();

        puzzlePreview.SetActive(true);
        SetPuzzlePiecesActive(false);

        StartCoroutine(HidePreviewAndStartGame());
    }

    private IEnumerator HidePreviewAndStartGame()
    {
        yield return new WaitForSeconds(previewDuration);

        puzzlePreview.SetActive(false);
        SetPuzzlePiecesActive(true);
    }

    private void SetPuzzlePiecesActive(bool active)
    {
        foreach (GameObject piece in puzzlePieces)
        {
            piece.GetComponent<CanvasGroup>().blocksRaycasts = active;
        }
    }

    void Awake()
    {
        if (Instance == null) Instance = this;
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
        piecesPlaced+=1;
        if (piecesPlaced == 5)
        {
            WinGame();
        }
        
    }

    private void WinGame()
    {
        level2Ended = true;

        if (LHSParticles != null)
        {
            LHSParticles.Play();
        }

        if (RHSParticles != null)
        {
            RHSParticles.Play();
        }

        winPanel.SetActive(true);
        audioSource.PlayOneShot(winSound);
        Debug.Log("Level 2 Complete!");

        ProgressTracker.Instance.level2Complete = true;

        //StartCoroutine(ReturnToBedroom());
    }

    //private IEnumerator ReturnToBedroom()
    //{
        //yield return new WaitForSeconds(10f);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Bedroom");
    //}


    private void LoseGame()
    {
        level2Ended = true;
        losePanel.SetActive(true);
        audioSource.PlayOneShot(loseSound);
        Debug.Log("Level 2 Failed.");
    }

    public void Next()
    {
        badgePanel.SetActive(true);
        winPanel.SetActive(false);
        Time.timeScale = 1;
    }
}




