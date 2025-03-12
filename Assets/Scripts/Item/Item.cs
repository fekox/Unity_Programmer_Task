using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ItemManager itemMananger;

    [SerializeField] private int ID;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI name;

    [Header("Values")]
    [SerializeField] private bool canPickUp;

    private ItemSO newItem;

    private void Awake()
    {
        newItem = itemMananger.GetRandomItem();
    }

    private void Start()
    {
        ID = newItem.ID;
        name.text = newItem.name;
        description.text = newItem.Description;

        canPickUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Collision");
        }
    }
}
