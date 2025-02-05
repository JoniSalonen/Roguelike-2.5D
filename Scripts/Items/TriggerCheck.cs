using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TriggerCheck : MonoBehaviour
{
    private bool isPlayerInsideTrigger = false; // Flag to track if the player is inside the trigger zone
    private bool isShopPanelEnabled = false; // Flag to track if the shop panel is enabled

    public Canvas shopPanel; // Reference to the shop panel

    public TextMeshProUGUI infoBox;
    public Image backgroundBox;



    void Start()
    {
        infoBox = GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>();
        backgroundBox = GameObject.Find("InfoBackground").GetComponent<Image>();
        backgroundBox.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = true; 
            infoBox.text = " Press E to shop"; 
            backgroundBox.enabled = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        // When the player leaves the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = false; 
            infoBox.text = "";
            backgroundBox.enabled = false; 
        }
    }

    public void Store()
    {
        if (isPlayerInsideTrigger == true && isShopPanelEnabled == false)
        {
            
            shopPanel.enabled = true;
            isShopPanelEnabled = true;
            Time.timeScale = 0; // Pause the game on the background

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else if ( isShopPanelEnabled == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            shopPanel.enabled = false;
            isShopPanelEnabled = false;
            Time.timeScale = 1; // Resume the game
        }

    }



}
