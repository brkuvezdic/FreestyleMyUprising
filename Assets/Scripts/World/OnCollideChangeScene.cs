// OnCollideChangeScene.cs
using UnityEngine;

public class OnCollideChangeScene : MonoBehaviour
{
    public LevelLoader levelLoader;
    public AudioSource doorAudioSource;
    public int shopSceneIndex;
    public int otherSceneIndex;
    public string targetTag = "Player"; // Tag to identify the player

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        doorAudioSource = GetComponent<AudioSource>();
        if (doorAudioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on the door!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            HandleSceneChange();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            HandleSceneChange();
        }
    }

    private void HandleSceneChange()
    {
        // Play audio if available
        if (doorAudioSource != null)
        {
            doorAudioSource.Play();
        }

        // Check the name of the GameObject this script is attached to
        if (gameObject.name == "PortalToShopppp")
        {
            StartCoroutine(levelLoader.LoadLevel(shopSceneIndex)); // Load the shop scene
        }
        else if (gameObject.name == "Portal za testiranje healtha")
        {
            StartCoroutine(levelLoader.LoadLevel(otherSceneIndex)); // Load the other scene
        }
        else
        {
            Debug.LogWarning("Unknown portal name: " + gameObject.name);
        }
    }
}
