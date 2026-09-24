using UnityEngine;

public class Renderer : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        sr.sortingOrder = Mathf.RoundToInt(transform.position.y * 100); 
    }

}
