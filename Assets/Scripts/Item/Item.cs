using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Sets the item's attributes and checks its collision with the player
/// </summary>
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

    /// <summary>
    /// Generates a random item and sets its attributes
    /// </summary>
    private void Start()
    {
        newItem = GameManager.Instance.itemMananger.GetRandomItem();

        ID = newItem.ID;
        image = newItem.image;
        description = newItem.description;
        _name = newItem.name;

        canPickUp = false;
    }

    /// <summary>
    /// If the player can grab the item, it is saved in their inventory and then the prefab is destroyed
    /// </summary>
    private void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E) && !GameManager.Instance.playerInventory.GetIsInventoryFull())
        {
            GameManager.Instance.playerInventory.AddItem(ID);
            GameManager.Instance.inventoryUIManager.UpdateInventoryUI();
            canPickUp = false;
            GameManager.Instance.pickUpText.SetActive(canPickUp);

            if (!GameManager.Instance.playerInventory.GetIsInventoryFull()) 
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// If the player collides with the item, the pickUpText game object is enabled
    /// </summary>
    /// <param name="other">The player</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (GameManager.Instance != null)
            {
                canPickUp = true;

                if (!GameManager.Instance.playerInventory.GetIsInventoryFull())
                {
                    GameManager.Instance.pickUpText.SetActive(canPickUp);
                }

                else 
                {
                    GameManager.Instance.inventoryFullText.SetActive(canPickUp);
                }
            }
        }
    }

    /// <summary>
    /// If the player stops colliding with the item, the pickUpText and inventoryFullText game objects are disabled
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null && GameManager.Instance.pickUpText != null)
            {
                canPickUp = false;
                GameManager.Instance.pickUpText.SetActive(canPickUp);
                GameManager.Instance.inventoryFullText.SetActive(canPickUp);
            }
        }
    }
}
