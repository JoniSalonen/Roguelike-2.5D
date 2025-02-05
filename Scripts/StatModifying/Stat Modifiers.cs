using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JS.CharacterStats {
    // Enum to represent different types of stat modifiers
    public enum StatType
    {
        Flat = 100,         // Flat value modifier
        PercentAdd = 200,   // Percentage value modifier added to the base value
        PercentMult = 300,  // Percentage value modifier multiplied with the base value
    }

    // Class to represent stat modifiers
    public class StatModifiers
    {
        public readonly float Value;     // The value of the modifier
        public readonly StatType Type;   // The type of the modifier
        public readonly int Order;       // The order of the modifier
        public readonly object Source;   // The source of the modifier

        // Constructor with all parameters
        public StatModifiers(float value, StatType type, int order, object source)
        {
            Value = value;
            Type = type;
            Order = order;
            Source = source;
        }

        // Constructor with value and type parameters
        public StatModifiers(float value, StatType type) : this(value, type, (int)type, null) { }

        // Constructor with value, type, and order parameters
        public StatModifiers(float value, StatType type, int order) : this(value, type, order, null) { }

        // Constructor with value, type, and source parameters
        public StatModifiers(float value, StatType type, object source) : this(value, type, (int)type, source) { }
    }
}
