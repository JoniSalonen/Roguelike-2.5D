using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JS.timer;

namespace JS.enemyStats
{
    // This script is used to store the stats of the enemy so they can be read when the enemy is created
    public class EnemyStats : MonoBehaviour
    {
        [Header("Timer")]
        private GameObject timer; // Reference to the timer object

        [Header("Health")]
        public int health; // Current health of the enemy
        private int previousHealth; // Previous health value for comparison
        private bool maxedHealth = false; // Flag to check if health is maxed

        [Header("Damage")]
        public float damage; // Current damage of the enemy
        private float previousDamage; // Previous damage value for comparison
        private bool maxedDamage = false; // Flag to check if damage is maxed

        [Header("Coins")]
        public int coins; // Current coins of the enemy
        private int previousCoins; // Previous coins value for comparison
        private bool maxedCoins = false; // Flag to check if coins are maxed

        [Header("Time Scaling")]
        public int scaledTime; // Current scaled time
        private int timeScaling; // Time scaling value
        private int previousTimeScaling; // Previous time scaling value for comparison
        protected bool maxedTimeScaling = false; // Flag to check if time scaling is maxed

        [Header("Damage Reduction")]
        public int damageReduction; // Current damage reduction of the enemy
        public int dr; // Damage reduction value
        private int previousDamageReduction; // Previous damage reduction value for comparison
        private bool maxedDamageReduction = false; // Flag to check if damage reduction is maxed

        [Header("Speed")]
        public float speed; // Current speed of the enemy
        private float previousSpeed; // Previous speed value for comparison
        private bool maxedSpeed = false; // Flag to check if speed is maxed

        [Header("Crit Chance")]
        public float critChance; // Current critical chance of the enemy
        private float previousCritChance; // Previous critical chance value for comparison
        private bool maxedCritChance = false; // Flag to check if critical chance is maxed

        [Header("Crit Damage")]
        public float critDamage; // Current critical damage of the enemy
        private float previousCritDamage; // Previous critical damage value for comparison
        private bool maxedCritDamage = false; // Flag to check if critical damage is maxed

        // Default values for the enemy
        void Start()
        {
            // Find the timer object in the scene
            timer = GameObject.Find("Timer");

            // Initialize default values for the enemy stats
            health = 20;
            previousHealth = health;

            damage = 5;
            previousDamage = damage;

            coins = 5;
            previousCoins = coins;

            scaledTime = timeScaling;
            previousTimeScaling = timeScaling;

            damageReduction = 1;
            previousDamageReduction = damageReduction;

            speed = 0.75f;
            previousSpeed = speed;

            critChance = 0.02f;
            previousCritChance = critChance;

            critDamage = 1.1f;
            previousCritDamage = critDamage;

            dr = damageReduction;
        }

        // Updating the values of the enemy
        void FixedUpdate()
        {
            // Get the current time multiplier from the timer
            timeScaling = timer.GetComponent<Timer>().GetTimeMultiplier();

            // Update the scaling and check for max values
            MaxScaling();
            TimeScale();
            MaxScaleCheck();
        }

        // Method to handle maximum scaling of stats
        public void MaxScaling()
        {
            // Cap the scaled time at 95
            if (scaledTime >= 95)
            {
                scaledTime = 95;
            }
            else
            {
                scaledTime = timeScaling;
            }

            // If the scaled time has increased, update the stats
            if (scaledTime > previousTimeScaling)
            {
                coins += (int)(coins * (scaledTime * 0.1f) / 2);

                health += (int)(health * (scaledTime * 0.1f) / 2);
                damage += (damage * (scaledTime * 0.1f) / 2);
                damageReduction += (int)(damageReduction * (scaledTime * 0.1f) / 2);
                speed += (speed * (scaledTime * 0.1f) / 2);
                critChance += (critChance * (scaledTime * 0.1f) / 2);
                critDamage += (critDamage * (scaledTime * 0.1f) / 2);
            }
        }

        // Method to check if any stat has reached its maximum value
        public void MaxScaleCheck()
        {
            HealthScale();
            DamageScale();
            CritChanceScale();
            CritDamageScale();
            DamageReductionScale();
            SpeedScale();
            CoinScale();
        }

        // Method to handle time scaling
        public void TimeScale()
        {
            scaledTime = timeScaling;

            // Update the previous time scaling value if the current one is greater
            if (timeScaling >= previousTimeScaling)
            {
                previousTimeScaling = scaledTime;
            }

            // Cap the scaled time at 95 and set the maxed flag
            if (timeScaling >= 95)
            {
                scaledTime = 95;
                maxedTimeScaling = true;
            }
        }

        // Method to handle health scaling
        public void HealthScale()
        {
            if (maxedHealth)
            {
                health = 2500;
                return;
            }

            if (health <= previousHealth)
            {
                health = previousHealth;
            }
            else
            {
                previousHealth = health;

                if (health >= 2500)
                {
                    previousHealth = health;
                    maxedHealth = true;
                }
            }
        }

        // Method to handle damage scaling
        public void DamageScale()
        {
            if (maxedDamage)
            {
                damage = 2500;
                return;
            }

            if (damage <= previousDamage)
            {
                damage = previousDamage;
            }
            else
            {
                previousDamage = damage;

                if (damage >= 2500)
                {
                    previousDamage = damage;
                    maxedDamage = true;
                }
            }
        }

        // Method to handle critical chance scaling
        public void CritChanceScale()
        {
            if (maxedCritChance)
            {
                critChance = 0.15f;
                return;
            }

            if (critChance <= previousCritChance)
            {
                critChance = previousCritChance;
            }
            else
            {
                previousCritChance = critChance;

                if (critChance >= 0.15f)
                {
                    previousCritChance = critChance;
                    maxedCritChance = true;
                }
            }
        }

        // Method to handle critical damage scaling
        public void CritDamageScale()
        {
            if (maxedCritDamage)
            {
                critDamage = 2.0f;
                return;
            }
            if (critDamage <= previousCritDamage)
            {
                critDamage = previousCritDamage;
            }
            else
            {
                previousCritDamage = critDamage;

                if (critDamage >= 2.0f)
                {
                    previousCritDamage = critDamage;
                    maxedCritDamage = true;
                }
            }
        }

        // Method to handle damage reduction scaling
        public void DamageReductionScale()
        {
            if (maxedDamageReduction)
            {
                damageReduction = 90;
                return;
            }

            if (damageReduction <= previousDamageReduction)
            {
                damageReduction = previousDamageReduction;
            }
            else
            {
                previousDamageReduction = damageReduction;

                if (damageReduction >= 90)
                {
                    previousDamageReduction = damageReduction;
                    maxedDamageReduction = true;
                }
            }
        }

        // Method to handle speed scaling
        public void SpeedScale()
        {
            if (maxedSpeed)
            {
                speed = 5.0f;
                return;
            }

            if (speed <= previousSpeed)
            {
                speed = previousSpeed;
            }
            else
            {
                previousSpeed = speed;

                if (speed >= 5.0f)
                {
                    previousSpeed = speed;
                    maxedSpeed = true;
                }
            }
        }

        // Method to handle coin scaling
        public void CoinScale()
        {
            if (maxedCoins)
            {
                coins = 250;
                return;
            }

            if (coins <= previousCoins)
            {
                coins = previousCoins;
            }
            else
            {
                previousCoins = coins;

                if (coins >= 250)
                {
                    previousCoins = coins;
                    maxedCoins = true;
                }
            }
        }
    }
}
