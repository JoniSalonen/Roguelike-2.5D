using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JS.HealtBar { 
public class Health_Bar : MonoBehaviour
    {
        public Slider slider; // Reference to the slider component for health value display
        public Gradient gradient; // Gradient used to set the color of the health bar
        public Image fill; // Reference to the image component for health bar fill

        // Updates the health bar based on the current health value
        public void UpdateHealth(float currentHealth)
        {
            slider.value = currentHealth; // Set the slider value to the current health value
            fill.color = gradient.Evaluate(slider.normalizedValue); // Set the fill color based on the normalized slider value
        }

        // Sets the maximum health value for the health bar
        public void SetMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth; // Set the slider's maximum value to the maxHealth value
            fill.color = gradient.Evaluate(1f); // Set the fill color to the color at the end of the gradient
        }
    }
}
