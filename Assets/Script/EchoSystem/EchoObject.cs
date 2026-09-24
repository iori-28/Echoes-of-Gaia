using UnityEngine;

// This script manages the visibility of objects in the Echo system based on the player's Echo Vision status. It listens for changes in Echo Vision and updates the visibility of the associated object accordingly.
public class EchoObject : MonoBehaviour
{
  [Header("Echo Components")]
  [SerializeField] private EchoVision echoVision;

  [Header("Echo Object")]
  [SerializeField] private GameObject echoVisual;

  [Header("Settings")]
  [SerializeField] private bool hideOnStart = true;

  private void Awake()
  {
    if (echoVision == null)
    {
      echoVision = FindAnyObjectByType<EchoVision>();
    }
  }

  private void OnEnable()
  {
    if (echoVision != null)
    {
      echoVision.OnVisionChanged += UpdateObject;
    }
  }

  private void Start()
  {
    if (echoVisual == null)
    {
      echoVisual = gameObject;
    }

    if (hideOnStart)
    {
      echoVisual.SetActive(false);
    }

    if (echoVision != null)
    {
      UpdateObject(echoVision.IsVisionActive());
    }
  }

  private void OnDisable()
  {
    if (echoVision != null)
    {
      echoVision.OnVisionChanged -= UpdateObject;
    }
  }

  private void UpdateObject(bool isVisible)
  {
    if (echoVisual == null)
    {
      return;
    }

    echoVisual.SetActive(isVisible);
  }
}