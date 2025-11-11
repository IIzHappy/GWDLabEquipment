using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    public InputActionProperty triggerValue;

    public MeshFilter handMesh;

    public Mesh openHand;
    public Mesh closeHand;

    private void Update()
    {
        if (triggerValue.action.ReadValue<bool>())
        {
            handMesh.mesh = closeHand;
        }
        else
        {
            handMesh.mesh = openHand;
        }
    }
}
