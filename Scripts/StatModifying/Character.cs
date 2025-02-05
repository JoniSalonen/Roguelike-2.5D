using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JS.CharacterStats;
using System;

public class Character : MonoBehaviour
{
    // The character's life stat
    public CharacterStats Life;

    // The character's life regeneration stat
    public CharacterStats LifeRegen;

    // The character's movement speed stat
    public CharacterStats MovementsSpeed;

    // The character's damage stat
    public CharacterStats Damage;

    // The character's life steal stat
    public CharacterStats LifeSteal;

    // The character's attack speed stat
    public CharacterStats AttackSpeed;

    // The character's armour stat
    public CharacterStats Armour;

    // The character's critical hit multiplier stat
    public CharacterStats CritMult;

    // The character's critical hit chance stat
    public CharacterStats CritChance;
}
