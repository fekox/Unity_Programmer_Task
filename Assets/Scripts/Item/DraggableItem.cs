using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;

/// <summary>
///  Handles all the methods that control the item's logic with respect to the mouse
/// </summary>
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private Slot slot;

    [Header("Sign References")]
    [SerializeField] private GameObject descriptionSign;
    [SerializeField] private TextMeshProUGUI signName;
    [SerializeField] private TextMeshProUGUI signDescription;

    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryUIManager inventoryUIManager;

    [HideInInspector] public Transform parent;
    public Image image;

    /// <summary>
    /// When starting to drag the item, if that slot is not empty, it sets the item's parent and disables the item's raycast target
    /// </summary>
    /// <param name="eventData">Mouse input</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!slot.isEmpty)
        {
            parent = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
    }

    /// <summary>
    /// if the slot is not empty, disable the game object descriptionSign and set the object's position to the mouse position
    /// </summary>
    /// <param name="eventData">Mouse input</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (!slot.isEmpty) 
        {
            descriptionSign.SetActive(false);
            transform.position = Input.mousePosition;
        }
    }

    /// <summary>
    /// if the slot is empty, set that slot as its new parent and enable the item's raycast target
    /// </summary>
    /// <param name="eventData">Mouse input</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!slot.isEmpty)
        {
            transform.SetParent(parent);
            image.raycastTarget = true;
        }
    }

    /// <summary>
    /// If the slot is empty, set the item's name and description on the item description sign to then enable it
    /// </summary>
    /// <param name="eventData">Mouse input</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!slot.isEmpty)
        {
            slot.isCursorOver = true;
            signName.text = slot._name;
            signDescription.text = slot.description;
            descriptionSign.SetActive(true);
        }
    }

    /// <summary>
    /// Disable the item description sign
    /// </summary>
    /// <param name="eventData">Mouse input</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        slot.isCursorOver = false;
        descriptionSign.SetActive(false);
    }

    /// <summary>
    /// If the cursor is over the item and press the right mouse button, remove the item from the inventory and the UI
    /// </summary>
    private void Update()
    {
        if (slot.isCursorOver && Input.GetMouseButtonDown(1))
        {
            playerInventory.RemoveItem(slot.ID);
            inventoryUIManager.ResetSlotUI(slot);
        }
    }
}