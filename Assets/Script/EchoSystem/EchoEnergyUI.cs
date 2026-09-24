using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EchoEnergyUI : MonoBehaviour
{
    public Slider slider;
    public TMP_Text energyText;
    public EchoData echoData;

    private void Start()
    {
        if (echoData == null)
        {
            echoData = FindAnyObjectByType<EchoData>();
        }

        UpdateUI();
    }

    private void Update()
    {
        if (echoData == null)
        {
            return;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        slider.maxValue = echoData.MaxEchoEnergy;
        slider.value = echoData.EchoEnergy;

        energyText.text = $"{echoData.EchoEnergy} / {echoData.MaxEchoEnergy}";
    }
}