using System.IO;
using UnityEngine;

/// <summary>
/// It manages the saving and loading of the data
/// </summary>
public static class SaveSystem 
{
    private static string path = Path.Combine(Application.persistentDataPath, "inventory.json");

    /// <summary>
    /// It saves the player's inventory in a JSON file
    /// </summary>
    /// <param name="inventory">The player inventory</param>
    public static void SaveInventory(PlayerInventory inventory) 
    {
        InventoryData saveData = new InventoryData();

        foreach (var item in inventory.GetInventory()) 
        {
            saveData.itemsID.Add(item.ID);
        }

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }

    /// <summary>
    /// It checks if there is already saved data
    /// </summary>
    /// <returns></returns>
    public static InventoryData LoadInventory()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<InventoryData>(json);
        }

        return new InventoryData();
    }
}