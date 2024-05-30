using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip walkingSound;
    [SerializeField] private AudioClip runningSound;
    [SerializeField] private AudioClip damagedSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on the player! Adding one.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void PlayWalkingSound()
    {
        PlaySound(walkingSound, 1.0f);
    }

    public void PlayRunningSound()
    {
        PlaySound(runningSound, 1.5f);
    }

    public void PlayDamagedSound()
    {
        PlaySound(damagedSound, 1.0f);
    }

    private void PlaySound(AudioClip clip, float pitch)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.pitch = pitch;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioClip or AudioSource not set.");
        }
    }

    public void StopSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public bool IsPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }
}
