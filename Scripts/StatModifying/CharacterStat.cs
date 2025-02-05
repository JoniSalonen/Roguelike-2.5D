using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace JS.CharacterStats
{
    [Serializable]
    public class CharacterStats
    {
        // Base value of the character stat
        public float BaseValue;

        // Calculated value of the character stat
        public float Value
        {
            get
            {
                // Recalculate the value if there are changes or the base value has changed
                if (isChanges || BaseValue != lastBaseValue)
                {
                    //Debug.Log("Calculating the final value");
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isChanges = false;
                }
                return _value;
            }
        }

        protected bool isChanges = true; // Flag to indicate if there are changes
        protected float _value; // Cached value of the stat
        protected float lastBaseValue = float.MinValue; // Last base value to detect changes

        protected readonly List<StatModifiers> statModifiers; // List of stat modifiers
        public readonly ReadOnlyCollection<StatModifiers> StatModifiers; // Read-only collection of stat modifiers

        // Default constructor
        public CharacterStats()
        {
            statModifiers = new List<StatModifiers>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        // Constructor with base value
        public CharacterStats(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        // Add a modifier to the stat
        public virtual void AddModifier(StatModifiers modifier)
        {
            isChanges = true;
            statModifiers.Add(modifier);
            statModifiers.Sort(CompareModifierOrder);
            // Debug.Log("Modifier Added: " + modifier.Value);
        }

        // Remove a modifier from the stat
        public virtual bool RemoveModifier(StatModifiers modifier)
        {
            if (statModifiers.Remove(modifier))
            {
                isChanges = true;
                return true;
            }
            return false;
        }

        // Remove all modifiers from a specific source
        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool wasRemoved = false;

            // For loop in reverse to remove the latest modifier object first that was added 
            // if there are multiple modifiers from the same source they all are removed
            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source == source)
                {
                    isChanges = true;
                    wasRemoved = true;
                    statModifiers.RemoveAt(i);
                    //Debug.Log("Modifier Removed: " + statModifiers[i].Value);
                }
            }
            return wasRemoved;
        }

        // Compare the order of two stat modifiers
        // Flat -> PercentAdd -> PercentMult
        protected virtual int CompareModifierOrder(StatModifiers a, StatModifiers b)
        {
            if (a.Order < b.Order)
            {
                return -1;
            }
            else if (a.Order > b.Order)
            {
                return 1;
            }
            return 0;
        }

        // Calculate the final value of the stat
        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            // Iterate through each modifier and apply it to the final value
            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifiers modifier = statModifiers[i];
                if (modifier.Type == StatType.Flat)
                {
                    finalValue += modifier.Value;
                }
                else if (modifier.Type == StatType.PercentAdd)
                {
                    sumPercentAdd += modifier.Value;
                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (modifier.Type == StatType.PercentMult)
                {
                    finalValue *= 1 + modifier.Value;
                }
            }

            finalValue = (float)Math.Round(finalValue, 4);
            //Debug.Log("Final MovementSpeed Value Calculated: " + finalValue);
            return finalValue;
        }
    }
}
