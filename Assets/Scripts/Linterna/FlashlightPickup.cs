using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public void Pick()
    {
        Debug.Log("Recogiste la linterna");

        FlashlightInventory.instance.hasFlashlight = true;
        Destroy(gameObject);
    }
}
