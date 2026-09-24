using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Combat : MonoBehaviour
{
    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 1f;
    public int damage = 1;
    public LayerMask enemyLayer;

    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private PlayerMove playerMove;
    private Vector3 attackPointStartPosition;

    [SerializeField] private EchoPurification echoPurification;
    [SerializeField] private EchoCore echoCore;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMove = GetComponent<PlayerMove>();

        if (attackPoint != null)
        {
            attackPointStartPosition = attackPoint.localPosition;
        }

        if (echoPurification == null)
        {
            echoPurification = FindAnyObjectByType<EchoPurification>();
        }

        if (echoCore == null)
        {
            echoCore = GetComponent<EchoCore>();
        }
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            UpdateAttackDirection();

            anim.SetTrigger("Attack");
            Attack();
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Purify();
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (echoCore != null)
            {
                echoCore.ToggleEcho();
            }
            else
            {
                Debug.LogError("EchoCore belum ditemukan pada Player!");
            }
        }
    }

    private void UpdateAttackDirection()
    {
        if (playerMove == null || spriteRenderer == null)
            return;

        spriteRenderer.flipX = playerMove.FacingRight;

        Vector3 position = attackPointStartPosition;

        if (playerMove.FacingRight)
        {
            position.x = Mathf.Abs(position.x);
        }
        else
        {
            position.x = -Mathf.Abs(position.x);
        }

        attackPoint.localPosition = position;
    }

    private void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        foreach (Collider2D hit in hits)
        {
            EnemyPrototype enemy = hit.GetComponent<EnemyPrototype>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Debug.Log("Player Attack!");
    }


    private void Purify()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        foreach (Collider2D hit in hits)
        {
            EnemyPrototype enemy = hit.GetComponent<EnemyPrototype>();

            if (enemy == null)
                continue;

            if (!enemy.isStunned)
                continue;

            if (!enemy.playerInSweetSpot)
                continue;

            enemy.ExecutePurification();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange
        );
    }
}