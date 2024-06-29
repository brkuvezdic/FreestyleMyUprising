/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;
    Damagable playerDamagable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerDamagable = player.GetComponent<Damagable>();

        if (player == null)
        {
            Debug.Log("No player found in the scene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalculateSliderPercentage(playerDamagable.Health, playerDamagable.MaxHealth);
        healthBarText.text = "Health " + playerDamagable.Health + " / " + playerDamagable.MaxHealth;
    }

    private void OnEnable()
    {
        playerDamagable.healthChanged.AddListener(OnPlayerHealthChanged);
        playerDamagable.GetComponent<PlayerStats>().OnHealthChanged.AddListener(OnPlayerHealthChanged); // Add this line
    }

    private void OnDisable()
    {
        playerDamagable.healthChanged.RemoveListener(OnPlayerHealthChanged);
        playerDamagable.GetComponent<PlayerStats>().OnHealthChanged.RemoveListener(OnPlayerHealthChanged); // Add this line
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    public void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "Health " + newHealth + " / " + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}*/
