using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<ItemSO> inventory;
    [SerializeField] private ItemManager itemManager;

    [SerializeField] private InventoryUIManager inventoryUIManager;

    private List<ItemSO> allItems;

    private bool isInventoryFull = false;
    private bool showInventory = false;

    public GameObject playerInventoryUI;

    [Header("Values")]
    [SerializeField] private int maxInventorySize;

    void Start()
    {

        allItems = itemManager.GetAllItemsList();

        CheckSaveInventory();
    }

    public void AddItem(int id) 
    {
        if (inventory.Count >= maxInventorySize)
        {
            isInventoryFull = true;
            return;
        }

        if (inventory.Count < maxInventorySize)
        {
            isInventoryFull = false;

            for (int i = 0; i < allItems.Count; i++)
            {
                if (id == allItems[i].ID)
                {
                    inventory.Add(allItems[i]);
                }
            }
        }
    }

    public void RemoveItem(int ID) 
    {
        if (inventory.Count > 0) 
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

    public bool GetIsInventoryFull() 
    {
        return isInventoryFull;
    }

    public void ShowInventoryLogic() 
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            showInventory = !showInventory;

            playerInventoryUI.SetActive(showInventory);
        }

        if (showInventory == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        else 
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public List<ItemSO> GetInventory() 
    {
        return inventory;
    }

    public void CheckSaveInventory() 
    {
        InventoryData savedData = SaveSystem.LoadInventory();
        inventory.Clear();

        foreach (int ID in savedData.itemsID)
        {
            ItemSO item = allItems.Find(i => i.ID == ID);

            if (item != null)
            {
                inventory.Add(item);
            }
        }

        inventoryUIManager.UpdateInventoryUI();
    }

    void OnApplicationQuit()
    {
        SaveSystem.SaveInventory(this);
    }
}