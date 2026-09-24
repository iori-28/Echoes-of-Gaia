using UnityEngine;

// This script manages the corruption level of the Echo system, allowing for increases and decreases in corruption, as well as checking the current corruption level.
public class EchoCorruption : MonoBehaviour
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

  public void IncreaseCorruption(float amount)
  {
    echoData.Corruption += amount;

    if (echoData.Corruption > 100f)
    {
      echoData.Corruption = 100f;
    }

    Debug.Log($"Corruption increased by {amount}. Current Corruption: {echoData.Corruption}");
  }

  public void DecreaseCorruption(float amount)
  {
    echoData.Corruption -= amount;

    if (echoData.Corruption < 0)
    {
      echoData.Corruption = 0;
    }

    CheckCorruptionLevel();
  }

  public float GetCorruption()
  {
    return echoData.Corruption;
  }

  private void CheckCorruptionLevel() //terlalu banyak if, jadinya dibikin kaya gini
  {
    string status = echoData.Corruption switch
    {
      < 20f => "Low",
      < 50f => "Moderate",
      < 80f => "High",
      _ => "Corrupted"
    };
    Debug.Log($"Corruption Level: {status}");
  }
}