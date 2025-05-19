using UnityEngine;

//Title: How to Add MUSIC and SOUND EFFECTS to a Game in Unity | Unity 2D Platformer Tutorial #16
//Author:Murat
//Date: 10 May 2025
//Code Version: 
//Availability: https://www.youtube.com/watch?v=N8whM1GjH4w 


public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip ")]
    public AudioClip background;
    public AudioClip purr;
    public AudioClip meow;
    public AudioClip buttonClick;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
