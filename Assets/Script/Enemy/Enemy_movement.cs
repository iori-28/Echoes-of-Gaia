using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    public bool isChasing;
    private Rigidbody2D rb;
    private Transform Player;
    private int facingDirection = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private EnemyPrototype enemyPrototype;
    public float patrolSpeed = 1.5f;
    public float patrolRadius = 5f;
    public float chaseSpeed = 3f;
    public float waitTime = 2f;
    public float maxWalkTime = 3f;
    public float detectionRadius = 5f;
    private Vector2 startPosition;
    private Vector2 randomDestination;
    private float waitCounter;
    private float walkCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyPrototype = GetComponent<EnemyPrototype>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Player = playerObject.transform;
        }

        startPosition = transform.position;
        pickNewPatrolDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPrototype != null && enemyPrototype.isStunned)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (isChasing == true && Player != null)
        {
            if (Player.position.x > transform.position.x && facingDirection == -1 || Player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            }
            Vector2 direction = (Player.position - transform.position).normalized;
            rb.linearVelocity = direction * chaseSpeed;
        }
        else
        {
            Patrol();
        }
    }
    void Patrol()
    {
        float distanceToDest = Vector2.Distance(transform.position, randomDestination);
        if (distanceToDest > 0.1f)
        {
            if((randomDestination.x > transform.position.x && facingDirection == -1) || (randomDestination.x < transform.position.x && facingDirection == 1))
            {
                Flip();
            }
            Vector2 direction = (randomDestination - (Vector2)transform.position).normalized;
            rb.linearVelocity = direction * patrolSpeed;

            walkCounter -= Time.deltaTime;
            if(walkCounter <= 0)
            {
                pickNewPatrolDestination();
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                pickNewPatrolDestination();
            }
        }
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player == null)
            {
                Player = collision.transform;
            }
            isChasing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
    private void pickNewPatrolDestination()
    {
        float randomX = Random.Range(-patrolRadius, patrolRadius);
        float randomY = Random.Range(-patrolRadius, patrolRadius);
        randomDestination = startPosition + new Vector2(randomX, randomY);
        waitCounter = waitTime;
        walkCounter = maxWalkTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Vector2 drawStartPos = Application.isPlaying ? startPosition : (Vector2)transform.position;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(drawStartPos, patrolRadius);
    }
}
