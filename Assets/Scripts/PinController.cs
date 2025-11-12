using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class PinController : MonoBehaviour
{
    private XRGrabInteractable grab;
    private Rigidbody rb;

    private bool placed = false;
    private bool counted = false;
    private bool knockedOver = false;

    private const float KnockAngleThreshold = 25;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grab.selectExited.AddListener(OnReleased);
    }

    private void Update()
    {
        if (!placed || knockedOver) return;

        float angle = Vector3.Angle(transform.up, Vector3.up);
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
        if (placed) return;
        placed = true;

        rb.rotation = Quaternion.Euler(-90, 0, 0);
        rb.position = new Vector3 (rb.position.x, 1.101783f, rb.position.z);
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Debug.Log("Pin placed inside area");

        if (!counted)
        {
            counted = true;
            PinManager.Instance?.OnPinPlaced(this);
        }
    }
}
