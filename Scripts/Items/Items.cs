using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using JS.CharacterStats;
using UnityEditor;


namespace ShopItems
{

    public class MovementsSpeedItem
    {
        // Adds a movement speed modifier to the character
        public void AddItem(Character c)
        {
            c.MovementsSpeed.AddModifier(new StatModifiers(0.1f, StatType.Flat, this));
            c.MovementsSpeed.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("MS Item Added");

        }

        // Removes the movement speed modifier from the character
        public void RemoveItem(Character c)
        {
            c.MovementsSpeed.RemoveAllModifiersFromSource(this);
            Debug.Log(" MS Item Removed");
        }
    }

    public class AttackSpeedItem
    {
        // Adds an attack speed modifier to the character
        public void AddItem(Character c)
        {
            c.AttackSpeed.AddModifier(new StatModifiers(1, StatType.Flat, this));
            c.AttackSpeed.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("AS Item Added");

        }

        // Removes the attack speed modifier from the character
        public void RemoveItem(Character c)
        {
            c.AttackSpeed.RemoveAllModifiersFromSource(this);
            Debug.Log("AS Item Removed");
        }
    }

    public class ArmourItem
    {
        // Adds an armor modifier to the character
        public void AddItem(Character c)
        {
            c.Armour.AddModifier(new StatModifiers(10, StatType.Flat, this));
            c.Armour.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("Item Added");

        }

        // Removes the armor modifier from the character
        public void RemoveItem(Character c)
        {
            c.Armour.RemoveAllModifiersFromSource(this);
            Debug.Log("Item Removed");
        }

    }

    public class DamageItem
    {
        // Adds a damage modifier to the character
        public void AddItem(Character c)
        {
            c.Damage.AddModifier(new StatModifiers(10, StatType.Flat, this));
            c.Damage.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("DMG Item Added");

        }

        // Removes the damage modifier from the character
        public void RemoveItem(Character c)
        {
            c.Damage.RemoveAllModifiersFromSource(this);
            Debug.Log("DMG Item Removed");
        }
    }

    public class CritChanceItem
    {
        // Adds a critical chance modifier to the character
        public void AddItem(Character c)
        {
            c.CritChance.AddModifier(new StatModifiers(0.1f, StatType.Flat, this));
            c.CritChance.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("Crit Chance Item Added");

        }

        // Removes the critical chance modifier from the character
        public void RemoveItem(Character c)
        {
            c.CritChance.RemoveAllModifiersFromSource(this);
            Debug.Log("Crit Chance Item Removed");

        }
    }

    public class CritMultItem
    {
        // Adds a critical multiplier modifier to the character
        public void AddItem(Character c)
        {
            c.CritMult.AddModifier(new StatModifiers(0.1f, StatType.Flat, this));
            c.CritMult.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("Crit Mult Item Added");
        }

        // Removes the critical multiplier modifier from the character
        public void RemoveItem(Character c)
        {
            c.CritMult.RemoveAllModifiersFromSource(this);
            Debug.Log("Crit Mult Item Removed");
        }
    }

    public class HealthItem
    {
        // Adds a health modifier to the character
        public void AddItem(Character c)
        {
            c.Life.AddModifier(new StatModifiers(10, StatType.Flat, this));
            c.Life.AddModifier(new StatModifiers(0.01f, StatType.PercentMult, this));

        }

        // Removes the health modifier from the character
        public void RemoveItem(Character c)
        {
            c.Life.RemoveAllModifiersFromSource(this);
            Debug.Log("Health Item Removed");
        }
    }

    public class HealthRegenItem
    {
        // Adds a health regeneration modifier to the character
        public void AddItem(Character c)
        {
            c.LifeRegen.AddModifier(new StatModifiers(10, StatType.Flat, this));

        }

        // Removes the health regeneration modifier from the character
        public void RemoveItem(Character c)
        {
            c.LifeRegen.RemoveAllModifiersFromSource(this);
            Debug.Log("Health Regen Item Removed");
        }
    }

    public class LifeStealItem
    {
        // Adds a life steal modifier to the character
        public void AddItem(Character c)
        {
            c.LifeSteal.AddModifier(new StatModifiers(5, StatType.Flat, this));
        }

        // Removes the life steal modifier from the character
        public void RemoveItem(Character c)
        {
            c.LifeSteal.RemoveAllModifiersFromSource(this);
            Debug.Log("Attack Range Item Removed");
        }
    }
}