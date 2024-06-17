using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int physicalDamage = 10;
    public int magicDamage = 15;

    private Animator animator;
    private Damagable damagable;
    private HealthPopupManager healthPopupManager; // Add this line

    public UnityEvent<int, int> OnHealthChanged; // Add this event

    void Start()
    {
        animator = GetComponent<Animator>();
        damagable = GetComponent<Damagable>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the player!");
        }

        if (OnHealthChanged == null)
        {
            OnHealthChanged = new UnityEvent<int, int>();
        }

        LoadHealth();
        OnHealthChanged.Invoke(currentHealth, maxHealth); // Initialize UI with loaded values

        GameObject popupObject = GameObject.Find("HealthPopup"); // Find the popup in the scene
        if (popupObject != null)
        {
            healthPopupManager = popupObject.GetComponent<HealthPopupManager>(); // Get the popup manager component
        }
        else
        {
            Debug.LogError("HealthPopup not found in the scene!");
        }
    }

    void OnApplicationQuit()
    {
        SaveHealth();
    }

    void OnDisable()
    {
        SaveHealth();
    }

    void OnDestroy()
    {
        SaveHealth();
    }

    public void TakeDamage(int damage, Vector3 attackSource)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't go below zero
        OnHealthChanged.Invoke(currentHealth, maxHealth); // Trigger the event
        if (damagable != null)
        {
            damagable.Health = currentHealth;
        }
        if (animator != null)
        {
            animator.SetTrigger("TakeDamage");
        }
        if (currentHealth <= 0)
        {
            Die();
        }
        SaveHealth(); // Save health after taking damage
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (damagable != null)
        {
            damagable.Health = currentHealth;
        }
        OnHealthChanged.Invoke(currentHealth, maxHealth); // Trigger the event
        SaveHealth(); // Save health after healing
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<PlayerController>().enabled = false;
    }

    public void IncreaseHealthByTen()
    {
        maxHealth += 10;
        currentHealth += 10;
        OnHealthChanged.Invoke(currentHealth, maxHealth); // Trigger the event
        if (damagable != null)
        {
            damagable.MaxHealth = maxHealth;
            damagable.Health = currentHealth;
        }

            healthPopupManager.ShowPopup("Current health increased by 10. New health: " + currentHealth + " / " + maxHealth);
        Debug.Log("Current health increased by 10. New health: " + currentHealth + "/" + maxHealth);
        SaveHealth(); // Save health after increasing it
    }

    private void SaveHealth()
    {
        PlayerPrefs.SetInt("MaxHealth", maxHealth);
        PlayerPrefs.SetInt("CurrentHealth", currentHealth);
        PlayerPrefs.Save();
    }

    private void LoadHealth()
    {
        if (PlayerPrefs.HasKey("MaxHealth") && PlayerPrefs.HasKey("CurrentHealth"))
        {
            maxHealth = PlayerPrefs.GetInt("MaxHealth");
            currentHealth = PlayerPrefs.GetInt("CurrentHealth");
            if (damagable != null)
            {
                damagable.MaxHealth = maxHealth;
                damagable.Health = currentHealth;
            }
        }
    }
}
