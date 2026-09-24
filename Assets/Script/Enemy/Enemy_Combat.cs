using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;

    private EnemyPrototype enemyPrototype;

    private void Start()
    {
        enemyPrototype = GetComponent<EnemyPrototype>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyPrototype != null)
        {
            if (enemyPrototype.isStunned || enemyPrototype.isPurified)
            {
                return;
            }
        }

        collision.gameObject.GetComponent<PlayerHealth>()?.ChangeHealth(-damage);
    }
}