using UnityEngine;

// This script manages the state and visibility of echo zones, allowing them to be restored or corrupted.
public class EchoZone : MonoBehaviour
{
  [Header("Zone Objects")]
  [SerializeField] private GameObject corruptedObject;

  [SerializeField] private GameObject restoredObject;

  [Header("Settings")]
  [SerializeField] private bool restored = false;

  private void Start()
  {
    UpdateZone();
  }

  public void Restore()
  {
    if (restored)
    {
      return;
    }

    restored = true;

    UpdateZone();

    Debug.Log("Zone berhasil dipulihkan.");
  }

  public void Corrupt()
  {
    restored = false;

    UpdateZone();

    Debug.Log("Zone kembali terkorupsi.");
  }

  private void UpdateZone()
  {
    if (corruptedObject != null)
    {
      corruptedObject.SetActive(!restored);
    }

    if (restoredObject != null)
    {
      restoredObject.SetActive(restored);
    }
  }

  public bool IsRestored()
  {
    return restored;
  }
}