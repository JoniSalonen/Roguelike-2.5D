using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using JS.CharacterStats;
using UnityEditor;


namespace ShopItems
{
    public class TestItem
    {

        public void AddItem(Character c)
        {
            c.MovementSpeed.AddModifier(new StatModifiers(1, StatType.Flat, this));
            c.MovementSpeed.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("Item Added");

        }

        public void RemoveItem(Character c)
        {
            c.MovementSpeed.RemoveAllModifiersFromSource(this);
            Debug.Log("Item Removed");
        }
    }

    public class AttackSpeedItem
    {
        public void AddItem(Character c)
        {
            c.AttackSpeed.AddModifier(new StatModifiers(1, StatType.Flat, this));
            c.AttackSpeed.AddModifier(new StatModifiers(0.1f, StatType.PercentMult, this));
            Debug.Log("Item Added");

        }

        public void RemoveItem(Character c)
        {
            c.AttackSpeed.RemoveAllModifiersFromSource(this);
            Debug.Log("Item Removed");
        }
    }
}