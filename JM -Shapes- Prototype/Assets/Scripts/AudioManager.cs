using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private BeatManager beatManager;
    private AudioSource audioSource;
    public AudioClip soundToPlay;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        beatManager = GetComponent<BeatManager>();
    }

    void Start()
    {
        PlayEasySong();
    }
    public void PlayEasySong()
    {
        audioSource.clip = soundToPlay;
        audioSource.Play();
    }
}
