using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectrotation : MonoBehaviour
{
    private GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player_Controller");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(playerController.transform);
    }
}
