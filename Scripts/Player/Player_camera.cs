using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Reference to the player's transform
    public Vector3 offset;         // Offset position between the camera and player
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    void Start()
    {
        // Calculate the initial offset between the player and the camera
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Target position the camera should move to (player position + offset)
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera from its current position to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the new smoothed position to the camera
        transform.position = smoothedPosition;

        // Make sure the camera is always looking at the player
        transform.LookAt(player);
    }
}
