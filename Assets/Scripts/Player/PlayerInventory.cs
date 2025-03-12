using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<ItemSO> inventory;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private GameObject playerInventory;

    private List<ItemSO> allItems;

    private bool isInventoryFull = false;
    private bool showInventory = false;

    [Header("Values")]
    [SerializeField] private int maxInventorySize;

    void Start()
    {
        inventory = new List<ItemSO>();

        allItems = itemManager.GetAllItemsList();
    }

    public void AddItem(int id) 
    {
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

        if (inventory.Count >= maxInventorySize)
        {
            isInventoryFull = true;
        }
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

    public bool GetIsInventoryFull() 
    {
        return isInventoryFull;
    }

    public void ShowInventoryLogic() 
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            showInventory = !showInventory;

            playerInventory.SetActive(showInventory);
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
}
