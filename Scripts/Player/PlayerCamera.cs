using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform player;

    float yRotation;
    float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
       float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
       float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.Rotate(Vector3.up * mouseX);
        transform.LookAt(player);
    }
}
