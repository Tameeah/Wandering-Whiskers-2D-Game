using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spider : MonoBehaviour
{
    public int curHp;

    public int maxHp;

    public int spidersCaught;

    public Image healthBarFill;

    public GameObject[] spiderPrefabs; 

    public void Damage()
    {
        curHp--;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        if (curHp <= 0)
        {
            Caught();
        }
    }

    public void Caught()
    {
        GameManager.instance.AddSpiders(spidersCaught);
        SpiderManager.instance.ReplaceSpider(gameObject);
    }

}
