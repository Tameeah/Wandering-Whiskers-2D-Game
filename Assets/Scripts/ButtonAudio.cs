using UnityEngine;
public class ButtonAudio : MonoBehaviour
{
    public AudioClip[] Clips;
    private AudioSource audioSource;
    public ButtonSoundType soundType;

    public enum ButtonSoundType
    {
        regular,
        game,
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(ButtonSoundType soundType)
    {

        switch (soundType)
        {
            case ButtonSoundType.regular:
                audioSource.PlayOneShot(Clips[0]);
                break;
            case ButtonSoundType.game:
                audioSource.PlayOneShot(Clips[1]);
                break;
        }
    }

    public void PlayAssignedSound()
    {
        PlaySound(soundType);
    }
}
