using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

//Title: Create A 2D Idle Clicker Game in Unity! Tutorial 2 | Objectives To Click
//Author:CubicRogue
//Date: 19 April 2025

public class Spider : MonoBehaviour
{
    public int maxHp = 10;
    public int curHp;
    private bool isDead = false;
    public Image healthBarFill;
    public GameObject[] spiderPrefabs;
    private int totalSpiders = 3;
    private int spidersDestroyed = 0;

    public void Start()
    {
        curHp = maxHp;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Damage(); 
            //Debug.Log("")
        }
    }

    public void Damage()
    {
        if (isDead) return;

        curHp--; 
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        if (curHp <= 0)
        {
            Die();
        }
        Debug.Log("Im dying!");
    }

    public void Die()
    {
        spidersDestroyed++;

        if (spidersDestroyed >= totalSpiders)
        { 
            isDead = true;
            this.gameObject.SetActive(false);
            SpiderManager.instance.SpidersDestroyed();
        }
        
       
    }

}
