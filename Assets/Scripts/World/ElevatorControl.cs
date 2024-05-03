using UnityEngine;
using System.Collections;

public class ElevatorControl : MonoBehaviour
{
    public float targetHeight = 5f; // How high the elevator goes
    public float speed = 2f; // Speed of the elevator
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isActivated = false;

    void Start()
    {
        startPosition = transform.position; // Remember start position
        endPosition = new Vector3(startPosition.x, startPosition.y + targetHeight, startPosition.z); // Set the end position
    }

    void Update()
    {
        // Only move if activated
        if (isActivated)
        {
            // Move towards the end position
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
        else
        {
            // Return to the start position if not activated
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActivated = true; // Activate the elevator when the player steps on the trigger
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActivated = false; // Deactivate when the player steps off
        }
    }
}
