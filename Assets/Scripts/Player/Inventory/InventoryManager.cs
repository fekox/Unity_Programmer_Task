using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Slot> itemSlots;

    [SerializeField] private PlayerInventory playerInventory;

    private List<ItemSO> inventory;

    public void UpdateInventory() 
    {
        inventory = playerInventory.GetInventory();

        for (int i = 0; i < inventory.Count; i++) 
        {
            if (itemSlots[i].isEmpty)
            {
                itemSlots[i].image.sprite = inventory[i].image;
                itemSlots[i]._name.text = inventory[i]._name;
                itemSlots[i].description.text = inventory[i].description;
                itemSlots[i].isEmpty = false;
            }
        }
    }
}
