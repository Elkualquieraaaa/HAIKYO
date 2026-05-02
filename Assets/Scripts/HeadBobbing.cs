using UnityEngine;
using UnityEngine.InputSystem;

public class HeadBobbing : MonoBehaviour
{
    [Header("INPUT")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference sprintAction;

    [Header("CONFIGURACION")]
    [SerializeField] private float bobSpeedWalk = 6f;
    [SerializeField] private float bobSpeedRun = 6f;

    [SerializeField] private float bobAmountWalk = 0.05f;
    [SerializeField] private float bobAmountRun = 0.1f;

    private float timer;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.localPosition;
    }

    void Update()
    {
        DoHeadBob();
    }

    void DoHeadBob()
    {
        Vector2 move = moveAction.action.ReadValue<Vector2>();

        if (move.magnitude < 0.1f)
        {
            timer = 0;

            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos, Time.deltaTime);

            return;
        }

        bool isRunning = sprintAction.action.IsPressed();

        float speed = isRunning ? bobSpeedRun : bobSpeedWalk;
        float amount = isRunning ? bobAmountRun : bobAmountWalk;

        timer += Time.deltaTime * speed;

        float y = Mathf.Sin(timer) * amount;
        float x = Mathf.Cos(timer/2) * amount * 0.5f;

        transform.localPosition = new Vector3(initialPos.x + x, initialPos.y + y, initialPos.z);
    }
}
