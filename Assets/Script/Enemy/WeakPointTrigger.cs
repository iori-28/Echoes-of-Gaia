using UnityEngine;

public class WeakPointTrigger : MonoBehaviour
{
    [Tooltip("Reference to the enemy script")]
    public EnemyPrototype enemyScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            enemyScript.playerInSweetSpot = true;
            Debug.Log("[Q] Purify Spirit!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            enemyScript.playerInSweetSpot = false;
            Debug.Log("Hidden [Q] Purify Spirit!");

        }
    }
}
