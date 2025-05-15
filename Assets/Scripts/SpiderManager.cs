 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : MonoBehaviour  
{
    public GameObject[] spiderPrefabs;

    public Spider curSpider;

    public Transform canvas;

    public static SpiderManager instance;

    void Awake()
    {
        instance = this;
    }

    //Spawn Spider
    public void SpawnSpider()
    {
        GameObject spiderToSpawn = spiderPrefabs[3];
        spiderPrefabs[3] = null;
        spiderToSpawn.SetActive(false);
        GameObject obj = Instantiate(spiderToSpawn, canvas);

        curSpider = obj.GetComponent<Spider>();
    }


    //Replace Spider 

    public void ReplaceSpider(GameObject spider)
    {
        Destroy(spider);
        SpawnSpider();
    }
}

