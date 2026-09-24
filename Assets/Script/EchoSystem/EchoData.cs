using UnityEngine;

// This script serves as a data container for the Echo system, holding various properties such as Echo Energy, Memory, Corruption, and Echo Vision status. It provides public accessors for these properties, allowing other scripts to read and modify them as needed.
public class EchoData : MonoBehaviour
{
  [Header("Echo Status")]

  [SerializeField]
  private int echoEnergy = 100;

  [SerializeField]
  private int maxEchoEnergy = 100;

  [SerializeField]
  private float memory = 100f;

  [SerializeField]
  private float corruption = 0f;

  [SerializeField]
  private bool isEchoVision = false;

  // Echo Energy
  public int EchoEnergy
  {
    get { return echoEnergy; }
    set { echoEnergy = value; }
  }

  public int MaxEchoEnergy
  {
    get { return maxEchoEnergy; }
    set { maxEchoEnergy = value; }
  }

  // Memory
  public float Memory
  {
    get { return memory; }
    set { memory = value; }
  }

  // Corruption
  public float Corruption
  {
    get { return corruption; }
    set { corruption = value; }
  }

  // Echo Vision
  public bool IsEchoVision
  {
    get { return isEchoVision; }
    set { isEchoVision = value; }
  }

}