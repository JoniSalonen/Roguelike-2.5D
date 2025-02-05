using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class LoadingScreen : MonoBehaviour
{
    public Canvas hud;
    public GameObject loadingScreen;
    public GameObject loadingText;
    public Slider slider;
    public Image fill;

    private int loadProgress;
    private int maxLoad;
    private bool loadCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("Hud").GetComponent<Canvas>();
        loadingScreen.SetActive(true);
        hud.enabled = false;
        loadProgress = 0;
    }

    void Update()
    {
        if (!loadCompleted)
        {
            slider.value = loadProgress;
            if (loadProgress >= maxLoad)
            {
                loadCompleted = true;
                Debug.Log("Load Completed");
                LoadCompleted();
            }
        }
    }



    public void AddLoadProgress()
    {
        loadProgress += 1;
        
    }

    public void LoadCompleted()
    {
        hud.enabled = true;
        loadingScreen.SetActive(false);
    }

    public void SetMaxLoad(int MaxLoad)
    {
        slider.maxValue = MaxLoad;
        maxLoad = MaxLoad;
    }


}
