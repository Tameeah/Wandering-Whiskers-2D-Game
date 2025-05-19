using UnityEngine;

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

    private void Awake() => DontDestroyOnLoad(gameObject);

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) => SFXSource.PlayOneShot(clip);
}
