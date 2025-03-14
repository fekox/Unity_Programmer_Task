using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It manages the inventory UI
/// </summary>
public class InventoryUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Slot> itemSlots;

    [SerializeField] private PlayerInventory playerInventory;

    [Header("Default Data")]
    [SerializeField] private Sprite defaultImage;

    private List<ItemSO> inventory;

    private int maxItemsToCarry = 4;

    /// <summary>
    /// It updates the item data in the UI
    /// </summary>
    public void UpdateInventoryUI() 
    {
        ResetAllSlotsUI();

        inventory = playerInventory.GetInventory();

        for (int i = 0; i < inventory.Count; i++) 
        {
            if (itemSlots[i].isEmpty)
            {
                itemSlots[i].ID = inventory[i].ID;
                itemSlots[i].image.sprite = inventory[i].image;
                itemSlots[i]._name = inventory[i].name;
                itemSlots[i].description = inventory[i].description;
                itemSlots[i].isEmpty = false;
            }
        }
    }

    /// <summary>
    /// It resets the object's attributes
    /// </summary>
    /// <param name="newSlot">The slot you want to reset</param>
    public void ResetSlotUI(Slot newSlot)
    {
        newSlot.image.sprite = defaultImage;
        newSlot.isEmpty = true;
    }

    /// <summary>
    /// It resets all the slots
    /// </summary>
    public void ResetAllSlotsUI() 
    {
        for(int i = 0;i < maxItemsToCarry; i++) 
        {
            itemSlots[i].image.sprite = defaultImage;
            itemSlots[i].isEmpty = true;
        }
    }
}
