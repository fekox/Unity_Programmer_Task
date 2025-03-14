using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Contains the methods for the UI buttons
/// </summary>
public class ButtonsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInventory playerInventory;

    [SerializeField] private GameObject controlsSign;

    /// <summary>
    /// Saves the items in the inventory and restarts the level
    /// </summary>
    public void RestartGame()
    {
        SaveSystem.SaveInventory(playerInventory);
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Deactivates the game object controllerSign
    /// </summary>
    public void HideControlsSign() 
    {
        controlsSign.SetActive(false);
    }

    /// <summary>
    /// Close the apllication
    /// </summary>
    public void QuitGame() 
    {
        Application.Quit();
    }
}
