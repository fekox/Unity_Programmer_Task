using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    [Header("References")]

    [SerializeField] private TextMeshProUGUI nameData;
    [SerializeField] private TextMeshProUGUI descriptionData;

    public GameObject descriptionSign;

    [Header("Values")]
    public bool isEmpty = true;
    public bool isCursorOver = false;

    public int ID;
    public Image image;
    public string _name;
    public string description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            isCursorOver = true;
            nameData.text = _name;
            descriptionData.text = description;
            descriptionSign.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCursorOver = false;
        descriptionSign.SetActive(false);
    }

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
