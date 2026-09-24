using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyPrototype : MonoBehaviour
{
    public int hp = 3;
    public bool isStunned = false;
    public bool isPurified = false;

    public GameObject weakPointIndicator;

    [HideInInspector]
    public bool playerInSweetSpot = false;

    public Sprite purifiedSprite;

    [SerializeField] private EchoPurification echoPurification;

    private EnvironmentWaveManager waveManager;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        if (weakPointIndicator != null)
        {
            weakPointIndicator.SetActive(false);
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (echoPurification == null)
        {
            echoPurification = FindAnyObjectByType<EchoPurification>();
        }
        waveManager = FindAnyObjectByType<EnvironmentWaveManager>();
    }

    void Update()
    {
        if (isPurified)
            return;

        if (hp <= 0 && !isStunned)
        {
            isStunned = true;
            Debug.Log("Enemy Stunned!");
        }

        if (!isStunned)
            return;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.qKey.isPressed)
            {
                if (weakPointIndicator != null)
                    weakPointIndicator.SetActive(true);
            }
            else
            {
                if (weakPointIndicator != null)
                    weakPointIndicator.SetActive(false);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isStunned || isPurified)
            return;

        hp -= damage;

        Debug.Log("Enemy HP : " + hp);
        if(hp <=0 && !isStunned)
        {
            isStunned = true;
            Debug.Log("Enemy Stunned!");
        }
    }

    public void ExecutePurification()
    {
        if (echoPurification != null)
        {
           if (!echoPurification.Purify())
            {
                return;
            }
            ;
        }
        if (waveManager != null)
        {
            waveManager.TriggerPurifyEffect(transform.position);
        }

        isPurified = true;
        isStunned = false;

        if (weakPointIndicator != null)
        {
            weakPointIndicator.SetActive(false);
        }
        

        Debug.Log("Enemy Purified!");

        if (animator != null)
        {
            animator.enabled = false;
        }

        if (spriteRenderer != null && purifiedSprite != null)
        {
            spriteRenderer.sprite = purifiedSprite;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        Enemy_movement movement = GetComponent<Enemy_movement>();
        if (movement != null)
        {
            movement.enabled = false;
        }

        Enemy_Combat combat = GetComponent<Enemy_Combat>();
        if (combat != null)
        {
            combat.enabled = false;
        }

        gameObject.tag = "Untagged";

        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
        CheckAllEnemiesPurified();
    }
    private void CheckAllEnemiesPurified()
    {
        if (AreaManager.Instance != null)
        {
            AreaManager.Instance.ReportEnemyPurified();
        }
    }
}