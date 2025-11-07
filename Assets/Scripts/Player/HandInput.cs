using UnityEngine;
using UnityEngine.InputSystem;

public class HandInput : MonoBehaviour
{
    public InputActionProperty action;
    public bool _isGrabbing;

    void Start()
    {

    }


    void Update()
    {
        if (!_isGrabbing)
        {
            bool button = action.action.IsPressed();
            Debug.Log("grab");

        }
    }
}
