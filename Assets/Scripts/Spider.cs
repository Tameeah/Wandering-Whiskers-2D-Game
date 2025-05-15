using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Spider : MonoBehaviour
{
    public int curHp;
    public int maxHp;
    private bool isDead = false;
    public Image healthBarFill;
    public GameObject[] spiderPrefabs;

    public void Start()
    {
        curHp = maxHp;
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
    }

    public void Die()
    {
        isDead = true;
        gameObject.SetActive(false);
        SpiderManager.instance.SpidersDestroyed();
    }
}
