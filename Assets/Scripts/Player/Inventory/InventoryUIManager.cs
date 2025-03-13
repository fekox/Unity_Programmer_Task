using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Slot> itemSlots;

    [SerializeField] private PlayerInventory playerInventory;

    [Header("Default Data")]
    [SerializeField] private Sprite defaultImage;

    private List<ItemSO> inventory;

    private int maxItemsToUse = 4;

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

    public void RemoveItemFromInventoryLogic() 
    {
        //if (playerInventory.playerInventoryUI.activeInHierarchy) 
        //{
        //    for (int i = 0; i < itemSlots.Count; i++)
        //    {
        //        if (itemSlots[i].isCursorOver && Input.GetMouseButtonDown(1))
        //        {
        //            playerInventory.RemoveItem(itemSlots[i].ID);
        //            ResetSlotUI(itemSlots[i]);

        //            break;
        //        }
        //    }
        //}
    }

    public void ResetSlotUI(Slot newSlot)
    {
        newSlot.image.sprite = defaultImage;
        newSlot.isEmpty = true;
    }

    public void ResetAllSlotsUI() 
    {
        for(int i = 0;i < maxItemsToUse; i++) 
        {
            itemSlots[i].image.sprite = defaultImage;
            itemSlots[i].isEmpty = true;
        }
    }
}
