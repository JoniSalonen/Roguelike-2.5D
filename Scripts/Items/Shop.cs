using JS.CharacterStats;
using JS.Inventory;
using ShopItems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// The Shop class handles the shop functionality in the game.
public class Shop : MonoBehaviour
{
    // References to the character and inventory

    private Character character;

    private Inventory inventory;

    // UI element to display current coins
    [SerializeField]
    public TextMeshProUGUI currentCoins;

    // Button to sell items
    public Button sellButton;

    // References to different item types
    public MovementsSpeedItem movementSpeedItem;
    public AttackSpeedItem attackSpeedItem;
    public ArmourItem armourItem;
    public CritChanceItem critChanceItem;
    public CritMultItem critMultItem;
    public DamageItem damageItem;
    public HealthItem healthItem;
    public HealthRegenItem healthRegenItem;
    public LifeStealItem lifeStealItem;

    // Movement Speed Item properties
    [Header("Movement Speed Item")]
    [SerializeField]
    private TextMeshProUGUI priceMS;
    public Button buyButtonMS;
    private readonly int originalPriceMS = 15;
    private readonly int maxAmountMS = 10;
    private int amountMS = 0;
    private bool maxAmountReachedMS = false;

    // Attack Speed Item properties
    [Header("Attack Speed Item")]
    [SerializeField]
    private TextMeshProUGUI priceAS;
    public Button buyButtonAS;
    private readonly int originalPriceAS = 15;
    private readonly int maxAmountAS = 50;
    private int amountAS = 0;
    private bool maxAmountReachedAS = false;

    // Armour Item properties
    [Header("Armour Item")]
    [SerializeField]
    private TextMeshProUGUI priceArmour;
    public Button buyButtonArmour;
    private readonly int originalPriceArmour = 50;
    private readonly int maxAmountArmour = 20;
    private int amountArmour = 0;
    private bool maxAmountReachedArmour = false;

    // Crit Chance Item properties
    [Header("Crit Chance Item")]
    [SerializeField]
    private TextMeshProUGUI priceCritC;
    public Button buyButtonCritC;
    private readonly int originalPriceCritC = 30;
    private readonly int maxAmountCritC = 20;
    private int amountCritC = 0;
    private bool maxAmountReachedCritC = false;

    // Crit Multiplier Item properties
    [Header("Crit Multiplier Item")]
    [SerializeField]
    private TextMeshProUGUI priceCritM;
    public Button buyButtonCritM;
    private readonly int originalPriceCritM = 35;
    private readonly int maxAmountCritM = 100;
    private int amountCritM = 0;
    private bool maxAmountReachedCritM = false;

    // Damage Item properties
    [Header("Damage Item")]
    [SerializeField]
    private TextMeshProUGUI priceDmg;
    public Button buyButtonDmg;
    private readonly int originalPriceDmg = 25;
    private readonly int maxAmountDmg = 200;
    private int amountDmg = 0;
    private bool maxAmountReachedDmg = false;

    // Health Item properties
    [Header("Health Item")]
    [SerializeField]
    private TextMeshProUGUI priceHp;
    public Button buyButtonHp;
    private readonly int originalPriceHp = 15;
    private readonly int maxAmountHp = 200;
    private int amountHp = 0;
    private bool maxAmountReachedHp = false;

    // Health Regen Item properties
    [Header("Health Regen Item")]
    [SerializeField]
    private TextMeshProUGUI priceHpReg;
    public Button buyButtonHpReg;
    private readonly int originalPriceHpReg = 35;
    private readonly int maxAmountHpReg = 200;
    private int amountHpReg = 0;
    private bool maxAmountReachedHpReg = false;

    // Life Steal Item properties
    [Header("Life Steal Item")]
    [SerializeField]
    private TextMeshProUGUI priceLifeSteal;
    public Button buyButtonLifeSteal;
    private readonly int originalPriceLifeSteal = 40;
    private readonly int maxAmountLifeSteal = 20;
    private int amountLifeSteal = 0;
    private bool maxAmountReachedLifeSteal = false;

    // Reference to the shop panel canvas
    [Header("Canvas")]
    public Canvas shopPanel;

    // Initialize items in the Start method
    void Start()
    {
        character = GameObject.Find("Player_Controller").GetComponent<Character>();
        inventory = character.GetComponent<Inventory>();

        movementSpeedItem = new MovementsSpeedItem();
        attackSpeedItem = new AttackSpeedItem();
        armourItem = new ArmourItem();
        critChanceItem = new CritChanceItem();
        critMultItem = new CritMultItem();
        damageItem = new DamageItem();
        healthItem = new HealthItem();
        healthRegenItem = new HealthRegenItem();
        lifeStealItem = new LifeStealItem();
    }

    // Update method to refresh UI elements
    private void Update()
    {
        // Display the current amount of coins
        currentCoins.text = "" + inventory.coins;

        // Update prices for items based on inventory and max amount reached status
        if (maxAmountReachedMS == false)
        {
            priceMS.text = "" + (originalPriceMS + ((inventory.movementSpeedItem * 20)));
        }
        else
        {
            priceMS.text = "Maxed";
        }

        if (maxAmountReachedAS == false)
        {
            priceAS.text = "" + (originalPriceAS + (inventory.AttackSpeedItem * 5));
        }
        else
        {
            priceAS.text = "Maxed";
        }

        if (maxAmountReachedArmour == false)
        {
            priceArmour.text = "" + (originalPriceArmour + (inventory.ArmourItem * 5));
        }
        else
        {
            priceArmour.text = "Maxed";
        }

        if (maxAmountReachedCritC == false)
        {
            priceCritC.text = "" + (originalPriceCritC + (inventory.CritChanceItem * 5));
        }
        else
        {
            priceCritC.text = "Maxed";
        }

        if (maxAmountReachedCritM == false)
        {
            priceCritM.text = "" + (originalPriceCritM + (inventory.CritMultItem * 5));
        }
        else
        {
            priceCritM.text = "Maxed";
        }

        if (maxAmountReachedDmg == false)
        {
            priceDmg.text = "" + (originalPriceDmg + (inventory.DamageItem * 5));
        }
        else
        {
            priceDmg.text = "Maxed";
        }

        if (maxAmountReachedHp == false)
        {
            priceHp.text = "" + (originalPriceHp + (inventory.lifeItem * 5));
        }
        else
        {
            priceHp.text = "Maxed";
        }

        if (maxAmountReachedHpReg == false)
        {
            priceHpReg.text = "" + (originalPriceHpReg + (inventory.LifeRegenItem * 5));
        }
        else
        {
            priceHpReg.text = "Maxed";
        }

        if (maxAmountReachedLifeSteal == false)
        {
            priceLifeSteal.text = "" + (originalPriceLifeSteal + (inventory.LifeSteal * 5));
        }
        else
        {
            priceLifeSteal.text = "Maxed";
        }
    }

    // Buying the movement speed item
    public void BuyMovementItem()
    {
        // Calculate the current price of the movement speed item
        int currentPrice = originalPriceMS + (inventory.movementSpeedItem * originalPriceMS);
        int coins = inventory.coins;
        amountMS = inventory.movementSpeedItem;

        // Check if the maximum amount of movement speed items has been reached
        if (amountMS >= maxAmountMS)
        {
            maxAmountReachedMS = true;
        }
        else if (maxAmountReachedMS == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonMS.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonMS.enabled = true;
            movementSpeedItem.AddItem(character);
            Debug.Log("Current Movement Speed Value: " + character.MovementsSpeed.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add the item to the inventory
            inventory.movementSpeedItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonMS.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all movement speed items
    public void SellMovementItem()
    {
        // Enable the buy button
        buyButtonMS.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player based on the number of movement speed items sold
        inventory.coins = currentCoins + ((inventory.movementSpeedItem * 10) + (inventory.movementSpeedItem * 5));
        // Remove the item from the character
        movementSpeedItem.RemoveItem(character);

        // Reset the amount of movement speed items in the inventory
        amountMS = 0;
        inventory.movementSpeedItem = 0;
        maxAmountReachedMS = false;
    }

    // Buying the attack speed item
    public void BuyAttackSpeedItem()
    {
        // Calculate the current price of the attack speed item
        int currentPrice = originalPriceAS + (inventory.AttackSpeedItem * originalPriceAS);
        int coins = inventory.coins;
        amountAS = inventory.AttackSpeedItem;

        // Check if the maximum amount of attack speed items has been reached
        if (amountAS >= maxAmountAS)
        {
            maxAmountReachedAS = true;
        }
        else if (maxAmountReachedAS == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonAS.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonAS.enabled = true;
            attackSpeedItem.AddItem(character);
            Debug.Log("Current Attack Speed Value: " + character.AttackSpeed.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add the item to the inventory
            inventory.AttackSpeedItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonAS.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all attack speed items
    public void SellAttackSpeedItem()
    {
        // Enable the buy button
        buyButtonAS.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player based on the number of attack speed items sold
        inventory.coins = currentCoins + ((inventory.AttackSpeedItem * 5) + (inventory.AttackSpeedItem * 5));
        // Remove the item from the character
        attackSpeedItem.RemoveItem(character);

        // Reset the amount of attack speed items in the inventory
        amountAS = 0;
        inventory.AttackSpeedItem = 0;
        maxAmountReachedAS = false;
    }

    // Buying the armor item
    public void BuyArmourItem()
    {
        // Calculate the current price of the armor item
        int currentPrice = originalPriceArmour + (inventory.ArmourItem * originalPriceArmour);
        int coins = inventory.coins;
        amountArmour = inventory.ArmourItem;

        // Check if the maximum amount of armor items has been reached
        if (amountArmour >= maxAmountArmour)
        {
            maxAmountReachedArmour = true;
        }
        else if (maxAmountReachedArmour == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonArmour.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonArmour.enabled = true;
            armourItem.AddItem(character);
            Debug.Log("Current Armour Value: " + character.Armour.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add the item to the inventory
            inventory.ArmourItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonArmour.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all armor items
    public void SellArmourItem()
    {
        // Enable the buy button
        buyButtonArmour.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player based on the number of armor items sold
        inventory.coins = currentCoins + ((inventory.ArmourItem * 5) + (inventory.ArmourItem * 5));
        // Remove the item from the character
        armourItem.RemoveItem(character);

        // Reset the amount of armor items in the inventory
        amountArmour = 0;
        inventory.ArmourItem = 0;
        maxAmountReachedArmour = false;
    }


    // Buying the crit chance item
    public void BuyCritChanceItem()
    {
        // Calculate the current price of the crit chance item
        int currentPrice = originalPriceCritC + (inventory.CritChanceItem * originalPriceCritC);
        int coins = inventory.coins;
        amountCritC = inventory.CritChanceItem;

        // Check if the maximum amount of crit chance items has been reached
        if (amountCritC >= maxAmountCritC)
        {
            maxAmountReachedCritC = true;
        }
        else if (maxAmountReachedCritC == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonCritC.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonCritC.enabled = true;
            critChanceItem.AddItem(character);
            Debug.Log("Current Crit Chance Value: " + character.CritChance.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add item to the inventory
            inventory.CritChanceItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonCritC.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all crit chance items
    public void SellCritChanceItem()
    {
        // Enable the buy button
        buyButtonCritC.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player for selling all crit chance items
        inventory.coins = currentCoins + ((inventory.CritChanceItem * 5) + (inventory.CritChanceItem * 5));
        // Remove the item from the character
        critChanceItem.RemoveItem(character);

        // Reset the amount and inventory count
        amountCritC = 0;
        inventory.CritChanceItem = 0;
        maxAmountReachedCritC = false;
    }

    // Buying the crit multiplier item
    public void BuyCritMultItem()
    {
        // Calculate the current price of the crit multiplier item
        int currentPrice = originalPriceCritM + (inventory.CritMultItem * originalPriceCritM);
        int coins = inventory.coins;
        amountCritM = inventory.CritMultItem;

        // Check if the maximum amount of crit multiplier items has been reached
        if (amountCritM >= maxAmountCritM)
        {
            maxAmountReachedCritM = true;
        }
        else if (maxAmountReachedCritM == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonCritM.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonCritM.enabled = true;
            critMultItem.AddItem(character);
            Debug.Log("Current Crit Multiplier Value: " + character.CritMult.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add item to the inventory
            inventory.CritMultItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonCritM.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all crit multiplier items
    public void SellCritMultItem()
    {
        // Enable the buy button
        buyButtonCritM.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player for selling all crit multiplier items
        inventory.coins = currentCoins + ((inventory.CritMultItem * 5) + (inventory.CritMultItem * 5));
        // Remove the item from the character
        critMultItem.RemoveItem(character);

        // Reset the amount and inventory count
        amountCritM = 0;
        inventory.CritMultItem = 0;
        maxAmountReachedCritM = false;
    }

    // Buying the damage item
    public void BuyDamageItem()
    {
        // Calculate the current price of the damage item
        int currentPrice = originalPriceDmg + (inventory.DamageItem * originalPriceDmg);
        int coins = inventory.coins;
        amountDmg = inventory.DamageItem;

        // Check if the maximum amount of damage items has been reached
        if (amountDmg >= maxAmountDmg)
        {
            maxAmountReachedDmg = true;
        }
        else if (maxAmountReachedDmg == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonDmg.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonDmg.enabled = true;
            damageItem.AddItem(character);
            Debug.Log("Current Damage Value: " + character.Damage.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add item to the inventory
            inventory.DamageItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonDmg.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all damage items
    public void SellDamageItem()
    {
        // Enable the buy button
        buyButtonDmg.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player for selling all damage items
        inventory.coins = currentCoins + ((inventory.DamageItem * 5) + (inventory.DamageItem * 5));
        // Remove the item from the character
        damageItem.RemoveItem(character);

        // Reset the amount and inventory count
        amountDmg = 0;
        inventory.DamageItem = 0;
        maxAmountReachedDmg = false;
    }

    // Buying the health item
    public void BuyHealthItem()
    {
        // Calculate the current price of the health item
        int currentPrice = originalPriceHp + (inventory.lifeItem * originalPriceHp);
        int coins = inventory.coins;
        amountHp = inventory.lifeItem;

        // Check if the maximum amount of health items has been reached
        if (amountHp >= maxAmountHp)
        {
            maxAmountReachedHp = true;
        }
        else if (maxAmountReachedHp == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonHp.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonHp.enabled = true;
            healthItem.AddItem(character);
            Debug.Log("Current Health Value: " + character.Life.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add item to the inventory
            inventory.lifeItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonHp.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all health items
    public void SellHealthItem()
    {
        // Enable the buy button
        buyButtonHp.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player for selling all health items
        inventory.coins = currentCoins + ((inventory.lifeItem * 5) + (inventory.lifeItem * 5));
        // Remove the item from the character
        healthItem.RemoveItem(character);

        // Reset the amount and inventory count
        amountHp = 0;
        inventory.lifeItem = 0;
        maxAmountReachedHp = false;
    }

    // Buying the health regen item
    public void BuyHealthRegenItem()
    {
        // Calculate the current price of the health regen item
        int currentPrice = originalPriceHpReg + (inventory.LifeRegenItem * originalPriceHpReg);
        int coins = inventory.coins;
        amountHpReg = inventory.LifeRegenItem;

        // Check if the maximum amount of health regen items has been reached
        if (amountHpReg >= maxAmountHpReg)
        {
            maxAmountReachedHpReg = true;
        }
        else if (maxAmountReachedHpReg == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonHpReg.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonHpReg.enabled = true;
            healthRegenItem.AddItem(character);
            Debug.Log("Current Health Regen Value: " + character.LifeRegen.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add item to the inventory
            inventory.LifeRegenItem++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonHpReg.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all health regen items
    public void SellHealthRegenItem()
    {
        // Enable the buy button
        buyButtonHpReg.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player for selling all health regen items
        inventory.coins = currentCoins + ((inventory.LifeRegenItem * 5) + (inventory.LifeRegenItem * 5));
        // Remove the item from the character
        healthRegenItem.RemoveItem(character);

        // Reset the amount and inventory count
        amountHpReg = 0;
        inventory.LifeRegenItem = 0;
        maxAmountReachedHpReg = false;
    }

    // Buying the life steal item
    public void BuyLifeStealItem()
    {
        // Calculate the current price of the life steal item
        int currentPrice = originalPriceLifeSteal + (inventory.LifeSteal * originalPriceLifeSteal);
        int coins = inventory.coins;
        amountLifeSteal = inventory.LifeSteal;

        // Check if the maximum amount of life steal items has been reached
        if (amountLifeSteal >= maxAmountLifeSteal)
        {
            maxAmountReachedLifeSteal = true;
        }
        else if (maxAmountReachedLifeSteal == true)
        {
            // Disable the buy button if the maximum amount is reached
            buyButtonLifeSteal.enabled = false;
            Debug.Log("Max amount reached");
        }
        else if (coins >= currentPrice)
        {
            // Enable the buy button and add the item to the character if the player has enough coins
            buyButtonLifeSteal.enabled = true;
            lifeStealItem.AddItem(character);
            Debug.Log("Current Life Steal Value: " + character.LifeSteal.Value);
            // Remove coins from the player
            inventory.coins = coins - currentPrice;
            // Add item to the inventory
            inventory.LifeSteal++;
        }
        else
        {
            // Disable the buy button if the player cannot afford the item
            buyButtonLifeSteal.enabled = false;
            Debug.Log("Cannot afford item");
        }
    }

    // Selling all life steal items
    public void SellLifeStealItem()
    {
        // Enable the buy button
        buyButtonLifeSteal.enabled = true;
        int currentCoins = inventory.coins;
        // Add coins to the player for selling all life steal items
        inventory.coins = currentCoins + ((inventory.LifeSteal * 5) + (inventory.LifeSteal * 5));
        // Remove the item from the character
        lifeStealItem.RemoveItem(character);

        // Reset the amount and inventory count
        amountLifeSteal = 0;
        inventory.LifeSteal = 0;
        maxAmountReachedLifeSteal = false;
    }

    // Selling all items
    public void SellAllItems()
    {
        // Call the sell methods for all item types
        SellMovementItem();
        SellAttackSpeedItem();
        SellArmourItem();
        SellCritChanceItem();
        SellCritMultItem();
        SellDamageItem();
        SellHealthItem();
        SellHealthRegenItem();
        SellLifeStealItem();
    }
}
