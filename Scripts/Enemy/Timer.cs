using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JS.timer 
{
    public class Timer : MonoBehaviour
    {
        private float currentTime; 
        private int timeMultiplier; 

        // Update is called once per frame
        void FixedUpdate()
        {
            EnemyScaling();
        }

        // Method to calculate the time multiplier
        public void EnemyScaling()
        {
            currentTime += Time.deltaTime;

            // Calculate the time multiplier by dividing the current time by 60
            // enemies gaining multiplier every 75 seconds
            timeMultiplier = ((int)currentTime / 75); 

        }

        // Method to get the time multiplier
        public int GetTimeMultiplier()
        {
            return timeMultiplier;
        }

    }
}

