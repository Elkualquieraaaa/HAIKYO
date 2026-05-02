using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class movePlayer : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference sprintAction;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintSpeed = 9f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        float currentSpeed = sprintAction.action.IsPressed() ? sprintSpeed : speed;

        Vector3 move = transform.right * input.x + transform.forward * input.y;

        controller.Move(move * currentSpeed * Time.deltaTime);

        // gravedad
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}