using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SFXAudio : MonoBehaviour
{
    public AudioSource soundPlayer;

    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }
}
