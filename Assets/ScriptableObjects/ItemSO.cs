using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public int ID;

    [Header("Item description")]
    public string Name;

    public string Description;
}
