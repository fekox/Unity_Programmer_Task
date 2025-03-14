using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInventory playerInventory;
    public void RestartGame()
    {
        SaveSystem.SaveInventory(playerInventory);
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
