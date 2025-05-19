using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Title: How to Play or Stop Music Through Scenes in Unity
//Author:Man, B
//Date: 16 May 2025
//Code Version: 
//Availability: https://www.youtube.com/watch?v=ha6U8jHl9ak&t=1s


public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
