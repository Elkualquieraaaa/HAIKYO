using UnityEngine;
using UnityEngine.InputSystem;

public class Linterna : MonoBehaviour
{
    [SerializeField] private InputActionReference flashlightAction;

    [SerializeField] private Light flashlight;

    private bool isOn = false;

    private void Start()
    {
        isOn = false;
        flashlight.enabled = false;
    }

    void Update()
    {
        ToggleFlashlight();
    }

    void ToggleFlashlight()
    {
        if (!FlashlightInventory.instance.hasFlashlight) return;

        if (flashlightAction.action.triggered)
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
        }
    }
}
