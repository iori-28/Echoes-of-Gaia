using UnityEngine;

// This script manages the memory functionality of the Echo system, allowing for the reduction and restoration of memory, as well as checking the current memory level.
public class EchoMemory : MonoBehaviour
{
  [Header("Echo Components")]
  [SerializeField] private EchoData echoData;

  private void Awake()
  {
    if (echoData == null)
    {
      echoData = GetComponent<EchoData>();
    }
  }

  public void ReduceMemory(float amount)
  {
    echoData.Memory -= amount;

    if (echoData.Memory < 0)
    {
      echoData.Memory = 0;
    }
  }

  public void RestoreMemory(float amount)
  {
    echoData.Memory += amount;

    if (echoData.Memory > 100f)
    {
      echoData.Memory = 100f;
    }

    Debug.Log($"Memory restored by {amount}. Current Memory: {echoData.Memory}");
  }

  public float GetMemory()
  {
    return echoData.Memory;
  }
}