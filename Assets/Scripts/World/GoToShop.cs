// DoorInteraction.cs
using UnityEngine;
using static PlayerController;

public class GoToShop : MonoBehaviour, IInteractable
{
    public LevelLoader levelLoader;
    public AudioSource doorAudioSource;

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        doorAudioSource = GetComponent<AudioSource>();
        if (doorAudioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on the door!");
        }
    }

    public void Interact()
    {
        // Find the object with the specified name
        GameObject obj = GameObject.Find("PortalToShopppp");

                StartCoroutine(levelLoader.LoadLevel(5));
           

 
    }
}