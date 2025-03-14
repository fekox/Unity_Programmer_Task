using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// It contains the data of the slot
/// </summary>
public class Slot : MonoBehaviour, IDropHandler
{
    [Header("Values")]
    public bool isEmpty = true;
    public bool isCursorOver = false;

    public int ID;
    public Image image;
    public string _name;
    public string description;

    /// <summary>
    /// Drop the item into a new slot as long as it doesn't already contain an item
    /// </summary>
    /// <param name="eventData">The mouse input</param>
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parent = transform;
        }
    }
}
