using UnityEngine;

public class ResetPins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PinManager.Instance.ResetPins();
    }
}
