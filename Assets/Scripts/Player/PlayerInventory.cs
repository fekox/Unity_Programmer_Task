using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<ItemSO> inventory;

    [Header("Values")]
    [SerializeField] private int maxInventorySize;

    void Start()
    {
        inventory = new List<ItemSO>();

        for (int i = 0; i < maxInventorySize; i++) 
        {
            inventory.Add(new ItemSO());
        }
    }

    public void AddItem() 
    {
        inventory.Add(new ItemSO()); 
    }

    public void RemoveItem(int ID) 
    {
        if (inventory.Count < 0) 
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (ID == inventory[i].ID)
                {
                    inventory.Remove(inventory[i]);
                }
            }
        }
    }
}
