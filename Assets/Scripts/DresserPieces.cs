using System.Collections.Generic;
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
    public PuzzleManager puzzleManager;

    public bool hasStartedDrag;
    public GameObject currentlyDragging;

    public static List<DresserPieces> allDraggables = new List<DresserPieces>();


    //public PointerEventData eventData;
    public void Awake()
    {
        allDraggables.Add(this);
    }

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
    private bool isDragging = false;
    private Vector2 dragOffset;
    public void Update()
    {
        Camera eventCamera = canvas.renderMode == RenderMode.ScreenSpaceCamera ? canvas.worldCamera : null;

        if (Input.GetMouseButton(0))
        {
            if (!hasStartedDrag && currentlyDragging == null)
            {
                Vector2 localMousePos;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, eventCamera, out localMousePos))
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, eventCamera))
                    {
                        isDragging = true;
                        dragOffset = (Vector2)rectTransform.localPosition - localMousePos;
                        hasStartedDrag = true;
                        currentlyDragging = this.gameObject;

                        //Disable others from dragging
                        foreach (var DresserPieces in allDraggables)
                        {
                            if (DresserPieces.gameObject != this.gameObject)
                            {
                                DresserPieces.enabled = false;
                                Debug.Log("We On");
                            }
                        }
                    }

                    Debug.Log("HIII");
                }
            }
            else if (currentlyDragging != null)
            {
                // Another object is already being dragged
                // Prevents this object from initiating a drag
                Debug.Log($"Cannot start drag on {gameObject.name}, already dragging {currentlyDragging?.name}");
            }


        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                EndDrag();

                if (puzzleManager.piecesPlaced < 0)
                {
                    EndDrag();
                }
                else if (puzzleManager.piecesPlaced > 0)
                {
                    puzzleManager.piecesPlaced--;
                    EndDrag();
                    Debug.Log("Pieces Placed: " + puzzleManager.piecesPlaced);
                }

                isDragging = false;
                hasStartedDrag = false;
                currentlyDragging = null;
            }
            foreach (var DresserPieces in allDraggables)
            {
                DresserPieces.enabled = true;
                Debug.Log("We On");
            }



        }

        if (isDragging)
        {
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                eventCamera,
                out localPoint))
            {
                rectTransform.localPosition = localPoint + dragOffset;
            }
        }

    }
    public void EndDrag()
    {
        canvasGroup.blocksRaycasts = true;
        if (Vector3.Distance(transform.position, correctSlot.position) < snapDistance)
        {
            transform.position = correctSlot.position; //this makes all of them snap to the correct pos
            isPlaced = true;
            audioSource.PlayOneShot(clickSound);
            puzzleManager.PiecePlaced();

        }
        else
        {
            transform.position = startPosition;
        }
    }




}
