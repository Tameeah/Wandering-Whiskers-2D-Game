using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DresserPuzzle : MonoBehaviour
{
    private bool isDropped = false;
    private int totalPieces = 5;
    private int piecesPlaced = 0;
    public GameObject pink,orange,peach,red,yellow,pinkHolder,orangeHolder,peachHolder,redHolder, yellowHolder;

    Vector2 pinkInitialPos, orangeInitialPos, peachInitialPos, redInitialPos, yellowInitialPos;

    void Start()
    {
        pinkInitialPos = pink.transform.position;
        orangeInitialPos = orange.transform.position;
        peachInitialPos = peach.transform.position;
        redInitialPos = red.transform.position;
        yellowInitialPos = yellow.transform.position;
    }
    public void DragPink()
    {
        pink.transform.position = Input.mousePosition;
    }

    public void DragOrange()
    {
        orange.transform.position = Input.mousePosition;
    }

    public void DragPeach()
    {
        peach.transform.position = Input.mousePosition;
    }

    public void DragRed()
    {
        red.transform.position = Input.mousePosition;
    }

    public void DragYellow()
    {
        yellow.transform.position = Input.mousePosition;
    }

    public void DropPink()
    {
        float Distance = Vector3.Distance(pink.transform.position, pinkHolder.transform.position);
        if(Distance <50)
        {
            pink.transform.position = pinkHolder.transform.position;
        }
        else
        {
            pink.transform.position = pinkInitialPos;
        }
    }
    public void DropOrange()
    {
        float Distance = Vector3.Distance(orange.transform.position, orangeHolder.transform.position);
        if (Distance < 50)
        {
            orange.transform.position = orangeHolder.transform.position;
        }
        else
        {
            orange.transform.position = orangeInitialPos;
        }
    }
    public void DropPeach()
    {
        float Distance = Vector3.Distance(peach.transform.position, peachHolder.transform.position);
        if (Distance < 50)
        {
            peach.transform.position = peachHolder.transform.position;
        }
        else
        {
            peach.transform.position = peachInitialPos;
        }
    }
    public void DropRed()
    {
        float Distance = Vector3.Distance(red.transform.position, redHolder.transform.position);
        if (Distance < 50)
        {
            red.transform.position = redHolder.transform.position;
        }
        else
        {
            red.transform.position = redInitialPos;
        }
    }
    public void DropYellow()
    {
        float Distance = Vector3.Distance(yellow.transform.position, yellowHolder.transform.position);
        if (Distance < 50)
        {
            yellow.transform.position = yellowHolder.transform.position;
        }
        else
        {
            yellow.transform.position = yellowInitialPos;
        }
    }

    public void Drop ()
    {
        isDropped = true;
        gameObject.SetActive(false);
        PuzzleManager.instance.PiecesPlaced();
    }
}
