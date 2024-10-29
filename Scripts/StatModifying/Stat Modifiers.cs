using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JS.CharacterStats {
    public enum StatType
    {
        Flat = 100,
        PercentAdd = 200,
        PercentMult = 300,
    }

    public class StatModifiers
    {
        public readonly float Value;
        public readonly StatType Type;
        public readonly int Order;
        public readonly object Source;

        public StatModifiers(float value, StatType type, int order, object source)
        {
            Value = value;
            Type = type;
            Order = order;
            Source = source;
        }

        public StatModifiers(float value, StatType type) : this(value, type, (int)type, null) { }


        public StatModifiers( float value, StatType type, int order) : this(value, type, order, null) { }

        public StatModifiers(float value, StatType type, object source) : this(value, type, (int)type, source) { }
    }
}
