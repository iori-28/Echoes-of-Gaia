using UnityEngine;
using System.Collections;
public class EnvironmentWaveManager : MonoBehaviour
{
    public static EnvironmentWaveManager Instance;
    public float waveSpeed = 25f;
    public float targetMaxRadius = 60f;
    private Coroutine activeWaveCoroutine;

    private void Awake()
    {   
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
        Shader.SetGlobalFloat("_PurifyRadius", 0f);
        Shader.SetGlobalFloat("_IsPurified", 0f);
    }

    public void TriggerPurifyEffect(Vector2 spiritPosition)
    {
        Shader.SetGlobalVector("_PurifyCenter", spiritPosition);

        if(activeWaveCoroutine != null)
        {
            StopCoroutine(activeWaveCoroutine);
        }
        activeWaveCoroutine = StartCoroutine(AnimateWaveExpansion());
    }
    private IEnumerator AnimateWaveExpansion()
    {
        float currentRadius = 0f;
        Shader.SetGlobalFloat("_PurifyRadius", currentRadius);
        
        while (currentRadius < targetMaxRadius)
        {
            currentRadius += waveSpeed * Time.deltaTime;
            Shader.SetGlobalFloat("_PurifyRadius", currentRadius);
            yield return null;
        }
    }

    public void TriggerFullAreaPurification()
    {
        Shader.SetGlobalFloat("_IsPurified", 1f);
        Debug.Log("Full area purification triggered.");
    }
}
