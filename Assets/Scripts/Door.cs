
using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredItem = "Key";

    public void TryOpen()
    {
        if (PlayerInventory.instance.HasItem(requiredItem))
        {
            Debug.Log("Puerta Abierta");

            PlayerInventory.instance.RemoveItem(requiredItem);

            Destroy(gameObject);
        }

        else
        {
            Debug.Log("Necesitas " + requiredItem);
        }
    }
}
