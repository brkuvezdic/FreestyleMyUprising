using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int physicalDamage = 10;
    public int magicDamage = 15;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the player!");
        }
    }

    // Adjusted to take a second argument for the attack source
    public void TakeDamage(int damage, Vector3 attackSource)
    {
        currentHealth -= damage;
        if (animator != null)
        {
            animator.SetTrigger("TakeDamage");
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<PlayerController>().enabled = false; 
    }
}
