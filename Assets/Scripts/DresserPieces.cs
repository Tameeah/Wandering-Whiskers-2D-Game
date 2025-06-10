using UnityEngine;
using UnityEngine.EventSystems;

public class DresserPieces : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string correctSlotName; // Name of the correct slot GameObject
    public AudioClip snapSound;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;
    private bool isPlaced = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Try to find the drop target under pointer
        GameObject target = eventData.pointerEnter;
        if (target != null && target.name == correctSlotName)
        {
            rectTransform.position = target.transform.position;
            isPlaced = true;

            if (snapSound && PuzzleManager.Instance)
            {
                AudioSource.PlayClipAtPoint(snapSound, Camera.main.transform.position);
            }

            PuzzleManager.Instance.PiecePlaced();
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}

