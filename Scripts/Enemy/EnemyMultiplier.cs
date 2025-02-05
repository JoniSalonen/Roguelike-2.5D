using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace JS.EnemyMult
{
    public class EnemyMultiplier : MonoBehaviour
    {
        public float enemyValue;

        // TODO ADD MORE ENEMIES
        public float GetMultiplier(string colName)
        {
            // Check the name of the collider and set the enemy value accordingly
            // This is used to scale the enemy stats based on the enemy type
            // Can be adjusted to fit the game's balance and more enemies can be added as needed
            if (colName == "Imp")
            {
                enemyValue = 0.65f; 
            }
            else if (colName == "Treant")
            {
                enemyValue = 1f; 
            }
            else if(colName == "Spider")
            {
                enemyValue = 0.95f;
            }
            else if (colName == "EliteImp")
            {
                enemyValue = 1.2f; 
            }
            else if (colName == "BossImp")
            {
                enemyValue = 1.5f; 
            }
            else
            {
                enemyValue = 1f; // Set enemy value to 1 if the collider name is not recognized
            }

            return enemyValue; // Return the enemy value
        }
    }
}
