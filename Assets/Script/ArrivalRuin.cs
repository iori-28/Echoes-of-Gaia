using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;


public class ArrivalRuin : MonoBehaviour, Interactable
{
    public string Forest2;
    public GameObject Player;
    public CinemachineCamera Camera;
    public static string arrivaldoor = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        PlayerPosition();
    }
    void PlayerPosition()
    {
        if(arrivaldoor != "")
        {
            GameObject spawnpoint = GameObject.Find(arrivaldoor);
            if (spawnpoint != null)
            {
                Player.transform.position = spawnpoint.transform.position;
            } 
        }
        if(Camera != null && Player != null)
        {
            Camera.Follow = Player.transform;
        }
    }
    public void Interact()
    {
        SceneManager.LoadScene(Forest2);
    }
        
}
