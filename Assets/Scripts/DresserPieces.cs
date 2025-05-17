using UnityEngine;
using UnityEngine.EventSystems;

public class DresserPieces : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform targetPosition;
    public float snapDistance = 50f;

    private Vector3 originalPosition;
    private bool isPlacedCorrectly = false;
    private Canvas canvas;
    private PuzzleManager puzzleManager;

    [System.Obsolete]
    void Start()
    {
        originalPosition = transform.position;
        canvas = GetComponentInParent<Canvas>();
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlacedCorrectly) return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isPlacedCorrectly) return;

        transform.position += (Vector3)eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Vector3.Distance(transform.position, targetPosition.position) < snapDistance)
        {
            transform.position = targetPosition.position;

            if (!isPlacedCorrectly)
            {
                isPlacedCorrectly = true;
                puzzleManager.PiecesPlacedCorrectly();
            }
        }
        else
        {
            if (isPlacedCorrectly)
            {
                isPlacedCorrectly = false;
                puzzleManager.PieceRemovedFromCorrect();
            }

            transform.position = originalPosition;
        }
    }
}