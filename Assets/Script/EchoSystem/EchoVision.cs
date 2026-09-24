using System;
using UnityEngine;

// This script manages the vision functionality of the Echo system, allowing for the activation and deactivation of Echo Vision, as well as checking if Echo Vision is currently active.
public class EchoVision : MonoBehaviour
{
    [Header("Echo Components")]
    [SerializeField] private EchoData echoData;

    //event
    public event Action<bool> OnVisionChanged;

    private void Awake()
    {
        if (echoData == null)
        {
            echoData = GetComponent<EchoData>();
        }
    }

    public void EnableVision()
    {
        if (echoData.IsEchoVision)
        {
            return;
        }

        echoData.IsEchoVision = true;
        OnVisionChanged?.Invoke(true);
        Debug.Log("Echo Vision Activated");
    }

    public void DisableVision()
    {
        if (!echoData.IsEchoVision)
        {
            return;
        }

        echoData.IsEchoVision = false;
        OnVisionChanged?.Invoke(false);
        Debug.Log("Echo Vision Deactivated");
    }

    public void ToggleVision()
    {
        if (echoData.IsEchoVision)
        {
            DisableVision();
        }
        else
        {
            EnableVision();
        }
    }

    public bool IsVisionActive()
    {
        return echoData.IsEchoVision;
    }
}