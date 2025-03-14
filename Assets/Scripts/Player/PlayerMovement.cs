using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It manages the logic for the player's movement
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController characterController;

    [Header("Values")]
    [SerializeField] private float speed;

    /// <summary>
    /// It executes the player's movement logic
    /// </summary>
    public void MovementLogic() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        characterController.Move(movement * speed * Time.deltaTime);
    }
}
