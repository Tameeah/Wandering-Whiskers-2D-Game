using UnityEngine;

//Title: Week 11 - Enumerations & Sounds
//Author:Hayes, A
//Date: 12 May 2025
//Code Version: 
//Availability: https://ulwazi.wits.ac.za/courses/81381/files/8885573?module_item_id=924746


public class ButtonAudio : MonoBehaviour
{
    public AudioClip[] Clips;
    private AudioSource audioSource;
    public ButtonSoundType soundType;

    public enum ButtonSoundType
    {
        click,
        game,
        spider,
        Dresser,
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(ButtonSoundType soundType)
    {

        switch (soundType)
        {
            case ButtonSoundType.click:
                audioSource.PlayOneShot(Clips[0]);
                break;
            case ButtonSoundType.game:
                audioSource.PlayOneShot(Clips[1]);
                break;
            case ButtonSoundType.spider:
                audioSource.PlayOneShot(Clips[2]);
                break;
            case ButtonSoundType.Dresser:
                audioSource.PlayOneShot(Clips[3]);
                break;
        }
    }

    public void PlayAssignedSound()
    {
        PlaySound(soundType);
    }
}
