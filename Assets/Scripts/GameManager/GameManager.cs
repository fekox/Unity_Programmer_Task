using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Executes the logic for the player's movement, the player's view, and the inventory
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerLook playerLook;
    [SerializeField] private PlayerMovement playerMovement;
    
    public PlayerInventory playerInventory;
    public ItemManager itemMananger;
    public GameObject pickUpText;
    public GameObject inventoryFullText;
    public InventoryUIManager inventoryUIManager;

    [Header("Values")]
    public static GameManager Instance;

    /// <summary>
    /// Create an instance of the object
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Locks the cursor
    /// </summary>
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    /// <summary>
    /// Executes the logic for the player's movement and the player's view
    /// </summary>
    private void FixedUpdate()
    {
        playerLook.LookLogic();
        playerMovement.MovementLogic();
    }

    /// <summary>
    /// Executes the logic for the inventory
    /// </summary>
    private void Update()
    {
        playerInventory.ShowInventoryLogic();
    }
}
