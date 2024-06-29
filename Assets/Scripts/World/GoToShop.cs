// DoorInteraction.cs
/*using UnityEngine;
using static PlayerController;

public class GoToShop : MonoBehaviour, IInteractable
{
    public LevelLoader levelLoader;
    public AudioSource doorAudioSource;

     public int shopSceneIndex;
    public int otherSceneIndex;

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
        // Check the name of the GameObject this script is attached to
        if (gameObject.name == "PortalToShopppp")
        {
            StartCoroutine(levelLoader.LoadLevel(5)); // Load the shop scene
        }
        else if (gameObject.name == "Portal za testiranje healtha")
        {
            StartCoroutine(levelLoader.LoadLevel(2)); // Load the other scene
        }
        else
        {
            Debug.LogWarning("Unknown portal name: " + gameObject.name);
        }
    }

}*/