using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerLook playerLook;
    [SerializeField] private PlayerMovement playerMovement;
    
    public PlayerInventory playerInventory;
    public ItemManager itemMananger;
    public GameObject pickUpText;

    [Header("Values")]
    public static GameManager Instance;

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

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;    
    }

    void FixedUpdate()
    {
        playerLook.LookLogic();
        playerMovement.MovementLogic();
    }
}
