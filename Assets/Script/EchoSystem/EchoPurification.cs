using UnityEngine;

// This script manages the purification process of the Echo system, allowing for the use of Echo Energy to purify corrupted zones.
public class EchoPurification : MonoBehaviour
{
  [Header("Echo Components")]
  [SerializeField] private EchoCore echoCore;

  private void Awake()
  {
    if (echoCore == null)
    {
      echoCore = GetComponent<EchoCore>();
    }
  }

  public bool Purify()
  {
    if (echoCore == null)
    {
      Debug.LogError("EchoCore component is missing!");
      return false;
    }

    bool success = echoCore.UseEcho();

    if (success)
    {
      Debug.Log("Purification successful!");
      return true;
    }
    else
    {
      Debug.Log("Purification failed due to insufficient Echo Energy.");
      return false;
    }
  }
}