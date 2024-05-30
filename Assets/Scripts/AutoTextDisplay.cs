using TMPro;
using UnityEngine;

public class AutoTextDisplay : MonoBehaviour
{
    public GameObject interactionPopup; // Assign your UI text object to this in the inspector
    public TextMeshProUGUI dialogueText; // Assign the Text component in the inspector

    public string[] dialogues; // Assign specific dialogues for each NPC in the inspector

    private bool isPlayerInRange = false;
    private int dialogueIndex = 0; // To keep track of which dialogue text to display

    void Start()
    {
        interactionPopup.SetActive(false); // Assume the interactionPopup is disabled by default
    }

    void Update()
    {
        // If the player is in range and presses the "E" key, toggle the interaction popup
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            DisplayNextDialogue(); // Display the first dialogue automatically when player enters
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionPopup.SetActive(false);
            dialogueIndex = 0; // Reset dialogue index when player leaves
        }
    }

    public void DisplayNextDialogue()
{
    if (!interactionPopup.activeSelf)
    {
        interactionPopup.SetActive(true);
        dialogueIndex = 0; // Start from the beginning of the dialogues
    }

    if (dialogueIndex < dialogues.Length)
    {
        // Instead of setting dialogueText.text directly, we'll access the text from the dialogues array
        string dialogue = dialogues[dialogueIndex];
        dialogueText.text = dialogue; // Set the dialogue text to the current index
        dialogueIndex++; // Increment the index for the next call
    }
    else
    {
        interactionPopup.SetActive(false); // Hide the interactionPopup if at the end of the dialogues
        dialogueIndex = 0; // Reset the index
    }
}
}