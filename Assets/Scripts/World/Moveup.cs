/*using UnityEngine;

public class Door : MonoBehaviour, PlayerController.IInteractable
{
    private Animator animator;
    private BoxCollider2D physicalCollider; // Collider that blocks the player
    private BoxCollider2D triggerCollider; // Collider for interaction detection

    void Start()
    {
        animator = GetComponent<Animator>();
        // Assume you have correctly named your colliders or you can find them by position or size
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        if (colliders[0].isTrigger)
        {
            triggerCollider = colliders[0];
            physicalCollider = colliders[1];
        }
        else
        {
            triggerCollider = colliders[1];
            physicalCollider = colliders[0];
        }
    }

    public void Interact()
    {
        // Toggle the door open state and animate
        if (animator.GetBool("isOpen"))
        {
            animator.SetTrigger("Close");
            animator.SetBool("isOpen", false);
            // Optionally delay this action via a coroutine if you need to sync with animation
            physicalCollider.enabled = true;
        }
        else
        {
            animator.SetTrigger("Open");
            animator.SetBool("isOpen", true);
            physicalCollider.enabled = false;
        }
    }

    public void ToggleCollider()
    {
        physicalCollider.enabled = !physicalCollider.enabled; // Toggle the state based on the animation frame
    }

}
*/