using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioClip[] Clips;
    private AudioSource audioSource;
    public ButtonSoundType soundType;

    public enum ButtonSoundType
    {
        Purr,
        Click,
    }

    void Start ()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public void PlaySound(ButtonSoundType soundType)
    {
        switch (soundType)
        {
            case ButtonSoundType.Purr:
                audioSource.PlayOneShot(Clips[0]);
                break;

            case ButtonSoundType.Click:
                audioSource.PlayOneShot(Clips[1]);
                break;
        }
    }

    public void PlayAssignedSound()
    {
        PlaySound(soundType);
    }
}
