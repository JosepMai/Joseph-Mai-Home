using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private BeatManager beatManager;
    public GameObject beatManagers;
    private AudioSource audioSource;
    public AudioClip soundToPlay;
    public int CountdownTime;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        beatManager = GetComponent<BeatManager>();
    }

    void Start()
    {
        Invoke("PlayEasySong", CountdownTime);
    }
    public void PlayEasySong()
    {
        audioSource.clip = soundToPlay;
        audioSource.Play();
    }
}
