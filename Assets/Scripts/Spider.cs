using UnityEngine;
using UnityEngine.UI;

//Title: Create A 2D Idle Clicker Game in Unity! Tutorial 2 | Objectives To Click
//Author:CubicRogue
//Date: 19 April 2025

public class Spider : MonoBehaviour
{
    public int maxHp = 10;
    public int curHp;
    private bool isDead = false;

    public Image healthBarFill;

    public AudioClip squashSound;
    private AudioSource audioSource;

    void Start()
    {
        curHp = maxHp;
        healthBarFill.fillAmount = 1f;

        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        PlaySquashSound();
        Damage();
    }

    void PlaySquashSound()
    {
        if (squashSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(squashSound);
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

    void Die()
    {
        isDead = true;
            gameObject.SetActive(false);

        SpiderManager.instance.SpiderKilled();
    }
}
