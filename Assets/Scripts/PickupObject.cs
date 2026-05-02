using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public string itemID = "Key";

    public void Pick()
    {
        PlayerInventory.instance.AddItem(itemID);

        gameObject.SetActive(false);
    }

    
}
