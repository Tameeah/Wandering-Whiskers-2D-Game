using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpiderManager : MonoBehaviour
{
    public static SpiderManager instance;

    private int totalSpiders = 3;
    private int spidersDestroyed = 0;
    private bool level1Ended = false;
    public ParticleSystem winParticlesRHS;
    public ParticleSystem winParticlesLHS;


    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void SpidersDestroyed()
    {
        spidersDestroyed++;

        if(spidersDestroyed >= totalSpiders)
        {
            Level1Complete();
        }
    }

    void Level1Complete()
    {
        level1Ended = true;
        Debug.Log("Level Complete! You earned a reward!");
        UIManager.Instance.ShowWinPanel(); // Show win UI
        winParticlesLHS.Play();
        winParticlesRHS.Play();
    }

    public void Level1Failed()
    {
        if (!level1Ended)
        {
            level1Ended = true;
            Debug.Log("Level Failed! Not all spiders were caught.");
        }
    }

}
