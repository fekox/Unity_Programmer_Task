using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/// <summary>
/// It manages a list of all the items
/// </summary>
public class ItemManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<ItemSO> allItems;

    /// <summary>
    /// It generates a random item and returns it
    /// </summary>
    /// <returns></returns>
    public ItemSO GetRandomItem() 
    {
        int randomItem = Random.Range(0, allItems.Count);

        return allItems[randomItem];
    }

    /// <summary>
    /// It returns an item based on the ID received by the method
    /// </summary>
    /// <param name="id">The item ID</param>
    /// <returns></returns>
    public ItemSO GetItemByID(int id) 
    {
        return allItems[id];
    }

    /// <summary>
    /// It returns the entire list of items
    /// </summary>
    /// <returns></returns>
    public List<ItemSO> GetAllItemsList() 
    {
        return allItems;
    }
}
