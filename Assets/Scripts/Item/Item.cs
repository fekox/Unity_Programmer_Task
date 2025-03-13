using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private int ID;
    [SerializeField] private Sprite image;

    [SerializeField] private string _name;
    [SerializeField] private string description;

    [Header("Values")]
    [SerializeField] private bool canPickUp;

    private ItemSO newItem;

    private void Start()
    {
        newItem = GameManager.Instance.itemMananger.GetRandomItem();

        ID = newItem.ID;
        image = newItem.image;
        description = newItem.description;
        _name = newItem.name;

        canPickUp = false;
    }

    private void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E) && !GameManager.Instance.playerInventory.GetIsInventoryFull())
        {
            GameManager.Instance.playerInventory.AddItem(ID);
            GameManager.Instance.inventoryUIManager.UpdateInventoryUI();
            canPickUp = false;
            GameManager.Instance.pickUpText.SetActive(canPickUp);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (GameManager.Instance != null)
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
