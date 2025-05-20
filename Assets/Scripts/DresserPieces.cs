using UnityEngine;
using UnityEngine.EventSystems;

//Title: DresserPieces
//Author: ChatGPT
//Date: 17 May 2025
public class DresserPieces : MonoBehaviour/*, IBeginDragHandler, IDragHandler, IEndDragHandler*/
{
    public Transform correctSlot;
    public AudioClip clickSound;
    public float snapDistance = 50f; // Tweak as needed

    private CanvasGroup canvasGroup;
    private Vector3 startPosition;
    private AudioSource audioSource;
    private bool isPlaced = false;

    public Canvas canvas;
    public RectTransform rectTransform;


    //public PointerEventData eventData;

    void Start()
    {
        startPosition = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GameObject.Find("PuzzleManager").GetComponent<AudioSource>();
    }

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    if (isPlaced) return;
    //    canvasGroup.blocksRaycasts = false;
    //    // Debug.Log("Im got");
    //}
    public void BeginDrag()
    {
        if (isPlaced) return;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("Im got");
        //OnBeginDrag();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // Distance from the camera
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (isPlaced) return;
    //    transform.position = Input.mousePosition;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    canvasGroup.blocksRaycasts = true;
    //    if (Vector3.Distance(transform.position, correctSlot.position) < snapDistance)
    //    {
    //        transform.position = correctSlot.position;
    //        isPlaced = true;
    //        audioSource.PlayOneShot(clickSound);
    //        PuzzleManager.Instance.PiecePlaced();
    //    }
    //    else
    //    {
    //        transform.position = startPosition;
    //    }
    //}

    public bool IsPlacedCorrectly()
    {
        return isPlaced;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //OnBeginDrag(eventData);
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out localPoint))
            {
                rectTransform.localPosition = localPoint;

                Debug.Log("HIII");

            }
        }

    }
}
