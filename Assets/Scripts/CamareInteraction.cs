using UnityEngine;
using UnityEngine.InputSystem;


public class CamareInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;

    [SerializeField] private InputActionReference pickAction;

    private void OnEnable()
    {
        pickAction.action.Enable();
    }

    private void OnDisable()
    {
        pickAction.action.Disable();
    }

    void Update()
    {

        Debug.DrawLine(cam.transform.position, cam.transform.position + cam.transform.forward * distance, Color.red);
        if (pickAction.action.triggered)
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        



        if (Physics.Raycast(ray, out hit, distance))
        {
            PickupObject obj = hit.collider.GetComponent<PickupObject>();
            FlashlightPickup flash = hit.collider.GetComponent<FlashlightPickup>();

            if (flash != null)
            {
                flash.Pick();
                return;
            }

            if (obj != null)
            {
                obj.Pick();
                return;
            }

            Door door = hit.collider.GetComponent<Door>();
            if (door != null)
            {
                door.TryOpen();
            }
        }
    }


    
}
