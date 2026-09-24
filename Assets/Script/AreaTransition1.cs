using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AreaTransition1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string Ruin;
    public Image blank;
    public float speedTransition;
    public string spawnpoint;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(fade());
        }
    }
    IEnumerator fade()
    {
        Color colour = blank.color;
        while (colour.a < 1f)
        {
            colour.a += Time.deltaTime * speedTransition;
            blank.color = colour;
            yield return null;
        } 
        Arrival.arrivaldoor = spawnpoint;
         SceneManager.LoadScene(Ruin);
    }
}