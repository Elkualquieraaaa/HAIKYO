using UnityEngine;

public class FlashlightInventory : MonoBehaviour
{
    public static FlashlightInventory instance;

    public bool hasFlashlight = false;

    private void Awake()
    {
        instance = this;
    }
}
