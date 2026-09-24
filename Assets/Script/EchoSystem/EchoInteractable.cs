using System;
using UnityEngine;

public class EchoInteractable : MonoBehaviour, Interactable
{
    [Header("Interaction")]
    [SerializeField] private bool canInteract = true;

    [SerializeField] private bool requireEchoVision = true;

    [Header("Echo Components")]
    [SerializeField] private EchoVision echoVision;

    public event Action<EchoInteractable> OnInteracted;

    private void Awake()
    {
        if (echoVision == null)
        {
            echoVision = FindAnyObjectByType<EchoVision>();
        }
    }

    public bool CanInteract()
    {
        if (!canInteract)
        {
            return false;
        }

        if (requireEchoVision)
        {
            if (echoVision == null)
            {
                return false;
            }

            return echoVision.IsVisionActive();
        }

        return true;
    }

    public void Interact()
    {
        if (!CanInteract())
        {
            Debug.Log("Tidak bisa berinteraksi.");
            return;
        }

        Debug.Log("Interaksi berhasil : " + gameObject.name);

        OnInteracted?.Invoke(this);
    }

    public void SetInteractable(bool value)
    {
        canInteract = value;
    }
}