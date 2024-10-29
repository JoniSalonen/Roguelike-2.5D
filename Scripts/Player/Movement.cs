using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JS.CharacterStats;
using Unity.VisualScripting;
using ShopItems;

public class PlayerController : MonoBehaviour
{
    public Character character;
    private Rigidbody rb;
    public Animator animator;
    public TestItem item;
    public AttackSpeedItem attackSpeedItem;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Remove when the shop is implemented
        item = new TestItem();
        attackSpeedItem = new AttackSpeedItem();

    }

    void Update()
    {
        MovePlayer();


        // Remove when the shop is implemented 
        // for proofing the item system works
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackSpeedItem.AddItem(character);
            Debug.Log("Current Attack Speed Value: " + character.AttackSpeed.Value);

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            item.RemoveItem(character);
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveX, 0f, moveZ) * character.MovementSpeed.Value * Time.deltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPosition);

        animator.SetFloat("Speed_Up", -moveZ);
        animator.SetFloat("Speed_Down", moveZ);
        animator.SetFloat("Speed_Right", moveX);
        animator.SetFloat("Speed_Left", -moveX);


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Placeholder for grounded check functionality
        }
    }
}
