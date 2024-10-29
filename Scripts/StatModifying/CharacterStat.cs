using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace JS.CharacterStats
{
    [Serializable]
    public class CharacterStats
    {
        public float BaseValue;

        public float Value
        {
            get
            {
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

        protected bool isChanges = true;
        protected float _value;
        protected float lastBaseValue = float.MinValue;

        protected readonly List<StatModifiers> statModifiers;
        public readonly ReadOnlyCollection<StatModifiers> StatModifiers;

        public CharacterStats()
        {
            statModifiers = new List<StatModifiers>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public CharacterStats(float baseValue) : this()
        {
            BaseValue = baseValue;

        }

        public virtual void AddModifier(StatModifiers modifier)
        {
            isChanges = true;
            statModifiers.Add(modifier);
            statModifiers.Sort(CompareModifierOrder);
            // Debug.Log("Modifier Added: " + modifier.Value);
        }

        public virtual bool RemoveModifier(StatModifiers modifier)
        {
            if (statModifiers.Remove(modifier))
            {
                isChanges = true;
                return true;
            }
            return false;
        }

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

        // compares the stats base statType and applies the buff in the correct order
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

        // Calculating the final value of the stat
        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

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
