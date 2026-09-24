using UnityEngine;

public class WeakArea : MonoBehaviour
{
    public int hp = 3;
    public bool isStunned = false;
    public bool isPurified = false;
    public GameObject weakPointIndicator;

    [HideInInspector]
    public bool playerInSweetSpot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(weakPointIndicator != null)
        {
            weakPointIndicator.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPurified) return;
        if(hp <= 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                weakPointIndicator.SetActive(true);

                if (playerInSweetSpot && Input.GetKeyDown(KeyCode.Q))
                {
                    ExecutePurification();
                }
            }
            else
            {
                weakPointIndicator.SetActive(false);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if(!isStunned && !isPurified)
        {
            hp --;
            Debug.Log("WeakArea hp: " + hp);
        }
    }

    private void ExecutePurification()
    {
        isPurified = true;
        isStunned = false;
        weakPointIndicator.SetActive(false);
        Debug.Log("WeakArea purified!");
    }
}
