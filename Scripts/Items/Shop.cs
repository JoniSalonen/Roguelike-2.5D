using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShopItems;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    // Adding the character to the script
    // The effects of the items will be calcutaled and applied to the character when the player buys them
    public Character character;

    // Adding available items to the script 
    public TestItem item;
    public AttackSpeedItem attackSpeedItem;
    

    // Creating a list of items that the player can buy
    void Start()
    {
        // Instantiating the items
        item = new TestItem();
        attackSpeedItem = new AttackSpeedItem();

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Add a way to buy items from the shop 
        // For now, we will use the Q and E keys to simulate buying and selling items

        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackSpeedItem.AddItem(character);
            Debug.Log("Current Attack Speed Value: " + character.AttackSpeed.Value);

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            item.RemoveItem(character);
        }

    }
}
