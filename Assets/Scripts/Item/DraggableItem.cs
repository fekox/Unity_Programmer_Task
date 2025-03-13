using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;

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

    public void OnDrag(PointerEventData eventData)
    {
        if (!slot.isEmpty) 
        {
            descriptionSign.SetActive(false);
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!slot.isEmpty)
        {
            transform.SetParent(parent);
            image.raycastTarget = true;
        }
    }

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

    public void OnPointerExit(PointerEventData eventData)
    {
        slot.isCursorOver = false;
        descriptionSign.SetActive(false);
    }

    private void Update()
    {
        if (slot.isCursorOver && Input.GetMouseButtonDown(1))
        {
            playerInventory.RemoveItem(slot.ID);
            inventoryUIManager.ResetSlotUI(slot);
        }
    }
}