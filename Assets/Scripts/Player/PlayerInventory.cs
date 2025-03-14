using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the player's inventory
/// </summary>
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

    /// <summary>
    /// Get the list that contains all the items and then check if the inventory was already saved
    /// </summary>
    void Start()
    {
        allItems = itemManager.GetAllItemsList();

        CheckSaveInventory();
    }

    /// <summary>
    /// It adds an item to the inventory
    /// </summary>
    /// <param name="id">The item you want to add to the inventory</param>
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

    /// <summary>
    /// It removes an item from the inventory
    /// </summary>
    /// <param name="ID">The ID of the item you want to remove</param>
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

    /// <summary>
    /// It returns whether the inventory is full or not
    /// </summary>
    /// <returns></returns>
    public bool GetIsInventoryFull() 
    {
        return isInventoryFull;
    }

    /// <summary>
    /// It handles the logic to display the inventory
    /// </summary>
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

    /// <summary>
    /// It returns the player's inventory
    /// </summary>
    /// <returns></returns>
    public List<ItemSO> GetInventory() 
    {
        return inventory;
    }

    /// <summary>
    /// It checks if there is already a saved inventory
    /// </summary>
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

    /// <summary>
    /// It saves the inventory
    /// </summary>
    void OnApplicationQuit()
    {
        SaveSystem.SaveInventory(this);
    }
}