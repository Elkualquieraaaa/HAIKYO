using UnityEngine;
using System.Collections.Generic;


public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    private List<string> items = new List<string>();


    private void Awake()
    {
        instance = this;
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log("Recogiste " +  item);
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    public void RemoveItem(string item)
    {
        items.Remove(item);
    }
}
