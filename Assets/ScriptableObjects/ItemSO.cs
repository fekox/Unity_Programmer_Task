using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    [Header("References")]
    public Sprite image;

    [Header("Values")]
    public int ID;

    [Header("Description")]
    public string name;

    public string description;
}
