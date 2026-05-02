using UnityEngine;
using UnityEngine.InputSystem;

public class MoveMuase : MonoBehaviour
{
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private Transform playerBody;

    [Header("Sensibilidad")]
    [SerializeField] private float sensitivity = 0.05f;

    [Header("Suavizado")]
    [SerializeField] private float smoothTime = 0.05f;
    // 🔥 Mientras más alto → más suave pero más “pesado”
    // 🔥 Mientras más bajo → más rápido pero más directo

    private float xRotation = 0f;

    // 🔧 Variables internas para el suavizado
    private Vector2 currentLook;      // valor suavizado
    private Vector2 currentVelocity;  // referencia necesaria para SmoothDamp

    private void OnEnable()
    {
        lookAction.action.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        lookAction.action.Disable();
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // 🔹 Input crudo del mouse (delta)
        Vector2 rawLook = lookAction.action.ReadValue<Vector2>();

        // 🔥 SUAVIZADO REAL:
        // Esto hace que el movimiento no sea instantáneo,
        // sino que "alcance" el valor poco a poco → sensación AAA
        currentLook = Vector2.SmoothDamp(
            currentLook,
            rawLook,
            ref currentVelocity,
            smoothTime
        );

        // 🔥 IMPORTANTE:
        // NO usamos deltaTime porque el mouse ya es delta
        float mouseX = currentLook.x * sensitivity;
        float mouseY = currentLook.y * sensitivity;

        // 🔹 Rotación vertical (cámara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 🔹 Rotación horizontal (jugador)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}