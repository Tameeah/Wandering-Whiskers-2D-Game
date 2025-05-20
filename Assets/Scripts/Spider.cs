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

    public void Start()
    {
        curHp = maxHp;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Damage(2.5f);
            //Debug.Log("")
        }
    }

    public void Damage(float amount)
    {
        if (isDead) return;

        curHp-= (int)amount;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        if (curHp <= 0)
        {
            Die();
        }
        Debug.Log("Im dying!");
    }

    public void Die()
    {
        isDead = true;
        this.gameObject.SetActive(false);
        SpiderManager.instance.SpidersDestroyed();
    }

}
