using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;       // Reference to the player's transform

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
