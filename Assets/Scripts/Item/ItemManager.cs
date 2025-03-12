using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<ItemSO> allItems;

    public ItemSO GetRandomItem() 
    {
        int randomItem = Random.Range(0, allItems.Count);

        return allItems[randomItem];
    }

    public ItemSO GetItemByID(int id) 
    {
        return allItems[id];
    }

    public List<ItemSO> GetAllItemsList() 
    {
        return allItems;
    }
}
