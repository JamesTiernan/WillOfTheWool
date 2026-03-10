using UnityEngine;
using UnityEngine.InputSystem;

public class throwWool : MonoBehaviour
{
    public InputAction pressAction;

    private void OnEnable()
    {
        // Enable the action
        pressAction.Enable();

        // Subscribe to events
        pressAction.started += OnPressStarted;     // Button down
        pressAction.canceled += OnPressCanceled;   // Button up
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        pressAction.started -= OnPressStarted;
        pressAction.canceled -= OnPressCanceled;

        pressAction.Disable();
    }

    private void OnPressStarted(InputAction.CallbackContext ctx)
    {
        Debug.Log("Button Pressed");
        GetComponent<playerController>().ThrowStart();
    }

    private void OnPressCanceled(InputAction.CallbackContext ctx)
    {
        Debug.Log("Button Released");
        GetComponent<playerController>().ThrowComplete();
    }
}