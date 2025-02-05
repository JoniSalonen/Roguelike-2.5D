using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{

    public Slider slider; // Reference to the slider component for health value display
    public Image fill;
    // Start is called before the first frame update

    private void LoadValue(float currentLoad) 
    { 
        slider.value = currentLoad;
    }
}
