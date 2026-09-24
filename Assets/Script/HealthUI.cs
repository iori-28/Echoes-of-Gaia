using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthUI : MonoBehaviour
{
    public Slider slider;
    public TMP_Text healthText;
    public PlayerHealth health;

    private void OnEnable()
    {
        if(health != null)
        {
            
        health.OnHealthChanged += UpdateUI;
        UpdateUI(health.currentHealth, health.maxHealth);
        }
    }

    private void OnDisable()
    {
        if(health != null)
        {
            health.OnHealthChanged -= UpdateUI;
        }
    }
    private void UpdateUI(int currentHealth, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        healthText.text = $"{currentHealth} / {maxHealth}";
    }
}
