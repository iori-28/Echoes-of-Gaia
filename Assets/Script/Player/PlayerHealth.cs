using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Transform respawnPoint;
    private SpriteRenderer spriteRenderer;
    
    public event Action<int, int> OnHealthChanged;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            StartCoroutine(RespawnSequence());
            Debug.Log("Player has died. Respawning...");
        }
    }
    private IEnumerator RespawnSequence()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1.5f);   
        
        transform.position = respawnPoint.position;
        currentHealth = maxHealth;

        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        
        yield return new WaitForSeconds(0.5f);
        
        spriteRenderer.enabled = true;
        Debug.Log("Respawned at: " + respawnPoint.position);
    }
}
