using System.IO;
using UnityEngine;

public static class SaveSystem 
{
    private static string path = Application.dataPath + "/Saves/inventory.json";

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
    

