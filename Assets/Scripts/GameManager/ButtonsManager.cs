using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInventory playerInventory;

    [SerializeField] private GameObject controllsSign;
    public void RestartGame()
    {
        SaveSystem.SaveInventory(playerInventory);
        SceneManager.LoadScene(0);
    }

    public void HideControllsSign() 
    {
        controllsSign.SetActive(false);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
