using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips;

    private AudioSource audioSource;
    private int lastIndex = -1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomMusic();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }

    void PlayRandomMusic()
    {
        if (musicClips.Length == 0) return;

        int index;
        do
        {
            index = Random.Range(0, musicClips.Length);
        } while (index == lastIndex && musicClips.Length > 1);

        lastIndex = index;
        audioSource.clip = musicClips[index];
        audioSource.Play();
    }
}
