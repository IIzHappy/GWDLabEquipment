using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager Instance;

    private List<PinController> placedPins = new List<PinController>();
    private int knockedOverCount = 0;

    [SerializeField] TMP_Text pinsText;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    public void OnPinPlaced(PinController pin)
    {
        if (!placedPins.Contains(pin))
        {
            placedPins.Add(pin);
        }

        UpdateUI();
        Debug.Log($"Pin placed. Total pins: {placedPins.Count}");
    }

    public void OnPinKnockedOver(PinController pin)
    {
        if (placedPins.Contains(pin))
        {
            knockedOverCount++;
            UpdateUI();
            Debug.Log($"Pin knocked over! Count: {knockedOverCount} / {placedPins.Count}");
        }
    }
    public void OnPinStandUp(PinController pin)
    {
        if (placedPins.Contains(pin))
        {
            knockedOverCount--;
            UpdateUI();
            Debug.Log($"Count: {knockedOverCount} / {placedPins.Count}");
        }
    }

    public void ResetPins()
    {
        knockedOverCount = 0;

        foreach (PinController pin in placedPins)
        {
            if (pin != null)
                Destroy(pin.gameObject);
        }

        placedPins.Clear();
        UpdateUI();
        Debug.Log("Pins reset");
    }

    public void UpdateUI()
    {
        if (pinsText)
        {
            pinsText.text = $"{placedPins.Count - knockedOverCount} / {placedPins.Count}";
        }
    }
}
