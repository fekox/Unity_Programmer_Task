using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI description;

    public GameObject descriptionSign;

    public bool isEmpty = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            descriptionSign.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionSign.SetActive(false);
    }
}
