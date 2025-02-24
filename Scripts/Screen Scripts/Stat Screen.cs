using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JS.CharacterStats;
using Unity.VisualScripting;
using ShopItems;
using TMPro;
using JS.Inventory;


public class StatScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI attSpeed; // Text field for displaying attack speed

    [SerializeField]
    private TextMeshProUGUI attDmg; // Text field for displaying attack damage

    [SerializeField]
    private TextMeshProUGUI health; // Text field for displaying health

    [SerializeField]
    private TextMeshProUGUI healthRegen; // Text field for displaying health regeneration

    [SerializeField]
    private TextMeshProUGUI armour; // Text field for displaying armor

    [SerializeField]
    private TextMeshProUGUI critMult; // Text field for displaying critical hit multiplier

    [SerializeField]
    private TextMeshProUGUI critChance; // Text field for displaying critical hit chance

    [SerializeField]
    private TextMeshProUGUI movementsSpeed; // Text field for displaying movement speed

    [SerializeField]
    private TextMeshProUGUI currentMoney; // Text field for displaying current money

    [SerializeField]
    private TextMeshProUGUI lifeSteal; // Text field for displaying life steal

    [SerializeField]
    private Character character; // Reference to the Character script

    [SerializeField]
    private Inventory inventory; // Reference to the Inventory script

    private float attackSpeed; // Current attack speed value
    private float attackDmg; // Current attack damage value
    private float life; // Current life value
    private float lifeRegen; // Current life regeneration value
    private float movement; // Current movement speed value
    private float armor; // Current armor value
    private float crit; // Current critical hit chance value
    private float critMultiplier; // Current critical hit multiplier value
    private float lifeLeech; // Current life steal value
    private float money; // Current money value

    private bool isMSMax = false; // Flag indicating if movement speed is at its maximum
    private bool isArmourMax = false; // Flag indicating if armor is at its maximum
    private bool isCritChanceMax = false; // Flag indicating if critical hit chance is at its maximum




    // Update is called once per frame
    void Update()
    {
        // Update the current values from the Character script
        attackSpeed = (float)Math.Round(character.AttackSpeed.Value, 1);
        attackDmg = (float)Math.Round(character.Damage.Value, 1);
        life = (int)character.Life.Value;
        lifeRegen = (float)Math.Round(character.LifeRegen.Value, 1);
        armor = (float)Math.Round(character.Armour.Value, 1);
        critMultiplier = (float)Math.Round(character.CritMult.Value, 1);
        crit = (float)Math.Round(character.CritChance.Value, 1);
        movement = (float)Math.Round(character.MovementsSpeed.Value, 1);
        lifeLeech = (float)Math.Round(character.LifeSteal.Value, 1);
        money = (float)inventory.coins;

        MaxLimit(); // Apply maximum limits to the values

        // Update the text fields with the current values
        attSpeed.text = "Attack Speed: " + attackSpeed;
        lifeSteal.text = "LifeSteal: " + lifeLeech;
        attDmg.text = "Damage: " + attackDmg;
        health.text = "Life: " + life;
        healthRegen.text = "Life Regen: " + lifeRegen + "Life/s";
        armour.text = "Armour: " + armor + "%";
        critMult.text = "Mult: " + (100 + (critMultiplier * 100)) + "%";
        critChance.text = "Chance: " + crit + "%";
        movementsSpeed.text = "Movement Speed: " + movement;
        currentMoney.text = "" + money + "";

    }

    // Limit the values to their maximum range
    // Add more conditions when new features are implemented
    void MaxLimit()
    {
        if (movement >= 5 || isMSMax == false)
        {
            movement = 5.0f;
            isMSMax = true;
        }
        if (armor >= 95 && isArmourMax == false)
        {
            isArmourMax = true;
        }
       
        if (crit >= 100 && isCritChanceMax == false)
        {
            isCritChanceMax = true;
        }
        
    }
}
