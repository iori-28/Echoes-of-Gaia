using UnityEngine;

public class EchoCore : MonoBehaviour
{
    [Header("Echo Components")]
    [SerializeField]
    private EchoData echoData;

    [Header("Echo Cost")]
    [SerializeField] private int energyCost = 10;
    [SerializeField] private float memoryCost = 5f;
    [SerializeField] private float corruptionGain = 2f;
    [SerializeField] private EchoMemory echoMemory;
    [SerializeField] private EchoCorruption echoCorruption;

    [Header("Echo Mode")]
    [SerializeField] private bool echoActive = false;

    [SerializeField] private float energyDrainRate = 5f;

    private float energyTimer = 0f;

    private void Awake()
    {
        if (echoData == null)
        {
            echoData = GetComponent<EchoData>();
        }

        if (echoMemory == null)
        {
            echoMemory = GetComponent<EchoMemory>();
        }

        if (echoCorruption == null)
        {
            echoCorruption = GetComponent<EchoCorruption>();
        }
    }

    private void Update()
    {
        if (!echoActive)
        {
            return;
        }

        DrainEchoEnergy();
    }

    public bool UseEcho()
    {
        if (echoData.EchoEnergy < energyCost)
        {
            Debug.Log("Echo Energy tidak cukup!");
            return false;
        }

        echoData.EchoEnergy -= energyCost;
        echoMemory.ReduceMemory(memoryCost);
        echoCorruption.IncreaseCorruption(corruptionGain);

        Debug.Log("Echo digunakan!");

        return true;
    }

    public void EnableEcho()
    {
        if (echoData.EchoEnergy <= 0)
        {
            Debug.Log("Echo Energy habis!");
            return;
        }

        echoActive = true;

        Debug.Log("Echo Activated");
    }

    public void DisableEcho()
    {
        echoActive = false;

        energyTimer = 0f;

        Debug.Log("Echo Deactivated");
    }

    public void ToggleEcho()
    {
        if (echoActive)
        {
            DisableEcho();
        }
        else
        {
            EnableEcho();
        }
    }

    public bool IsEchoActive()
    {
        return echoActive;
    }

    private void DrainEchoEnergy()
    {
        energyTimer += Time.deltaTime;

        if (energyTimer >= 1f)
        {
            energyTimer = 0f;

            echoData.EchoEnergy -= Mathf.RoundToInt(energyDrainRate);

            if (echoData.EchoEnergy <= 0)
            {
                echoData.EchoEnergy = 0;
                DisableEcho();
            }
        }
    }

    public void RestoreEnergy(int amount)
    {
        echoData.EchoEnergy += amount;

        if (echoData.EchoEnergy > echoData.MaxEchoEnergy)
        {
            echoData.EchoEnergy = echoData.MaxEchoEnergy;
        }
    }

    public EchoData GetEchoData()
    {
        return echoData;
    }
}