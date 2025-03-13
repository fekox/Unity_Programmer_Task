using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject descriptionSign;

    [Header("Values")]
    public bool isEmpty = true;
    public bool isCursorOver = false;

    public int ID;
    public Image image;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            isCursorOver = true;
            descriptionSign.transform.position = Input.mousePosition;
            descriptionSign.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCursorOver = false;
        descriptionSign.SetActive(false);
    }

    public void UpdateSlotData()
    {
        
    }
}
