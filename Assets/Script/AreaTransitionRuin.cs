using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AreaTransitionRuin : MonoBehaviour, Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string Forest2;
    public Image blank;
    public float speedTransition;
    public string spawnpoint;
    public void Interact()
    {
        StartCoroutine(fade());
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
         SceneManager.LoadScene(Forest2);
    }
}