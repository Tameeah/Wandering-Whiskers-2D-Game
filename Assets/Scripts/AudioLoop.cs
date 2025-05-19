using UnityEngine;

//Title: AudioLoop
//Author: ChatGPT
//Date: 12 May 2025

public class TimedAudioLoop : MonoBehaviour
{
    public AudioSource audioSource;   
    public float loopDuration = 10f;  

    private float timer = 0f;
    private bool isPlaying = false;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Start looping
        audioSource.loop = true;
        audioSource.Play();
        isPlaying = true;
    }

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;

            if (timer >= loopDuration)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
