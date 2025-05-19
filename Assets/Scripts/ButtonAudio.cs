using UnityEngine;
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

    void Start() => audioSource = GetComponent<AudioSource>();

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

    public void PlayAssignedSound() => PlaySound(soundType);
}
