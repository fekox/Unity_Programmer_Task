using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ItemManager itemMananger;

    [SerializeField] private int ID;

    //TODO: Implemenet the item description and item name.
    //[SerializeField] private TextMeshProUGUI description;
    //[SerializeField] private TextMeshProUGUI name;

    [Header("Values")]
    [SerializeField] private bool canPickUp;

    private ItemSO newItem;

    private void Start()
    {
        newItem = itemMananger.GetRandomItem();

        ID = newItem.ID;
        canPickUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (GameManager.Instance != null && GameManager.Instance.pickUpText != null)
            {
                canPickUp = true;
                GameManager.Instance.pickUpText.SetActive(canPickUp);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null && GameManager.Instance.pickUpText != null)
            {
                canPickUp = false;
                GameManager.Instance.pickUpText.SetActive(canPickUp);
            }
        }
    }
}
