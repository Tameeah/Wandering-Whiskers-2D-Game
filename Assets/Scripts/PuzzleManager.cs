using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public GameObject circle,leaf,triangle,square,circleHolder,leafHolder,triangleHolder,squareHolder;

    Vector2 circleInitialPos, leafInitialPos, triangleInitialPos, squareInitialPos;

    void Start()
    {
        circleInitialPos = circle.transform.position;
        leafInitialPos = leaf.transform.position;
        triangleInitialPos = triangle.transform.position;
        squareInitialPos = square.transform.position;
    }
    public void Dragcircle()
    {
        circle.transform.position = Input.mousePosition;
    }

    public void Dragleaf()
    {
        leaf.transform.position = Input.mousePosition;
    }

    public void Dragtriangle()
    {
        triangle.transform.position = Input.mousePosition;
    }

    public void Dragsquare()
    {
        square.transform.position = Input.mousePosition;
    }

    public void Dropcircle()
    {
        float Distance = Vector3.Distance(circle.transform.position, circleHolder.transform.position);
        if(Distance <50)
        {
            circle.transform.position = circleHolder.transform.position;
        }
        else
        {
            circle.transform.position = circleInitialPos;
        }
    }
    public void Dropleaf()
    {
        float Distance = Vector3.Distance(leaf.transform.position, leafHolder.transform.position);
        if (Distance < 50)
        {
            leaf.transform.position = leafHolder.transform.position;
        }
        else
        {
            leaf.transform.position = leafInitialPos;
        }
    }
    public void Droptriangle()
    {
        float Distance = Vector3.Distance(triangle.transform.position, triangleHolder.transform.position);
        if (Distance < 50)
        {
            triangle.transform.position = triangleHolder.transform.position;
        }
        else
        {
            triangle.transform.position = triangleInitialPos;
        }
    }
    public void Dropsquare()
    {
        float Distance = Vector3.Distance(square.transform.position, squareHolder.transform.position);
        if (Distance < 50)
        {
            square.transform.position = squareHolder.transform.position;
        }
        else
        {
            square.transform.position = squareInitialPos;
        }
    }
}
