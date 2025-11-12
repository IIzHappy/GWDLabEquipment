using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class PinController : MonoBehaviour
{
    private XRGrabInteractable grab;
    private Rigidbody rb;

    private bool counted = false;
    private bool knockedOver = true;

    private const float KnockAngleThreshold = 25;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grab.selectExited.AddListener(OnReleased);
    }

    private void Update()
    {
        if (knockedOver) return;

        float angle = Vector3.Angle(transform.forward, Vector3.up);
        if (angle > KnockAngleThreshold)
        {
            knockedOver = true;
            PinManager.Instance?.OnPinKnockedOver(this);
        }
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (!PinArea.Instance.IsInsideZone(GetComponent<Collider>()))
        {
            Debug.Log("Pin released outside area");
            return;
        }

        PlacePin();
    }

    private void PlacePin()
    {
        rb.rotation = Quaternion.Euler(-90, 0, 0);
        rb.position = new Vector3(rb.position.x, 1.101783f, rb.position.z);

        Debug.Log("Pin placed inside area");

        if (!counted)
        {
            counted = true;
            PinManager.Instance?.OnPinPlaced(this);
        }
        else if(knockedOver)
        {
            PinManager.Instance?.OnPinStandUp(this);
        }
        knockedOver = false;
        PinManager.Instance?.UpdateUI();
    }
}
