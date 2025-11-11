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
            Debug.Log($"Pin placed. Total pins: {placedPins.Count}");
            pinsText.text = $"{placedPins.Count} / {placedPins.Count}";
        }
    }

    public void OnPinKnockedOver(PinController pin)
    {
        knockedOverCount++;
        Debug.Log($"Pin knocked over! Count: {knockedOverCount} / {placedPins.Count}");
        pinsText.text = $"{placedPins.Count - knockedOverCount} / {placedPins.Count}";
    }

    public int GetTotalPins() => placedPins.Count;
    public int GetKnockedOverCount() => knockedOverCount;

    public void ResetPins()
    {
        knockedOverCount = 0;
        placedPins.Clear();
    }
}
