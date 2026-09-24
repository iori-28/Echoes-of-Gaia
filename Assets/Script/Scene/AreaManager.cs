using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaManager Instance;
    public int totalEnemiesInArea;
    public EnvironmentWaveManager waveManager;
    void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        waveManager = FindAnyObjectByType<EnvironmentWaveManager>();
        totalEnemiesInArea = FindObjectsByType<EnemyPrototype>(FindObjectsInactive.Exclude).Length;
    }
    public void ReportEnemyPurified()
    {
        totalEnemiesInArea--;
        if (totalEnemiesInArea <= 0)
        {
            if (EnvironmentWaveManager.Instance != null)
            {
                EnvironmentWaveManager.Instance.TriggerPurifyEffect(transform.position);
            }
            EnvironmentWaveManager.Instance.TriggerFullAreaPurification();
            Debug.Log("All enemies purified.");
        }
    }
}
