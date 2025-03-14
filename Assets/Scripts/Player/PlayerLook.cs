using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It handles the logic for the player's view
/// </summary>
public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;

    [Header("Values")]
    [SerializeField] private float mouseSensivility = 150f;

    private float xRotation;

    /// <summary>
    /// It executes the logic for the player's vision
    /// </summary>
    public void LookLogic()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up, mouseX);
    }
}
