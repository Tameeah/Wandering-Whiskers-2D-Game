using UnityEngine;
using UnityEngine.EventSystems;

//Title: DresserPieces
//Author: ChatGPT
//Date: 17 May 2025
//Code Version: 
//Availability:

public class DresserPieces : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform correctSlot;
    public AudioClip clickSound;
    public float snapDistance = 50f; // Tweak as needed

    private CanvasGroup canvasGroup;
    private Vector3 startPosition;
    private AudioSource audioSource;
    private bool isPlaced = false;

    void Start()
    {
        startPosition = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GameObject.Find("PuzzleManager").GetComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (Vector3.Distance(transform.position, correctSlot.position) < snapDistance)
        {
            transform.position = correctSlot.position;
            isPlaced = true;
            audioSource.PlayOneShot(clickSound);
            PuzzleManager.Instance.PiecePlaced();
        }
        else
        {
            transform.position = startPosition;
        }
    }

    public bool IsPlacedCorrectly()
    {
        return isPlaced;
    }
}
