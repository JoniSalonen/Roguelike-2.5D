// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JS.CharacterStats;
using Unity.VisualScripting;
using ShopItems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player character and related components
    public Character character;
    private Rigidbody rb;
    public Animator animator;
    public Canvas stats;
    public Canvas hud;
    public Canvas shopPanel;
    public Canvas pauseMenu;

    // Pointer input position
    private Vector3 pointerInput;

    // Input actions for movement, attack, and pointer position
    [Header("Input Actions")]
    [SerializeField]
    private InputActionReference movement, attack, pointerPosition, tab, interact;

    // Reference to the weapon parent component
    private WeaponParent weaponParent;

    [SerializeField]
    private TriggerCheck triggerCheck;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Initialize components
        rb = GetComponent<Rigidbody>();
        stats = stats.GetComponent<Canvas>();
        hud = hud.GetComponent<Canvas>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        // Prevent the Rigidbody from rotating
        rb.freezeRotation = true;
        StartCoroutine(FindTriggerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current pointer position
        pointerInput = GetPointerPosition();

        // Move the player based on input
        MovePlayer();
    }

    // Enable input actions
    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
        tab.action.performed += OpenTab;
        interact.action.performed += OpenShop ;
    }

    // Disable input actions
    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        tab.action.performed -= OpenTab;
        interact.action.performed -= OpenShop;
    }

    private void OpenShop(InputAction.CallbackContext obj)
    {
        triggerCheck.Store();
    }

    private void OpenTab(InputAction.CallbackContext obj)
    {
        stats.enabled = !stats.enabled;
    }

    // Perform attack action
    private void PerformAttack(InputAction.CallbackContext obj)
    {
        weaponParent.Attack();
    }

    // Move the player based on input
    void MovePlayer()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Get the current movement speed from character stats
        float currentSpeed = character.MovementsSpeed.Value;

        // Cap the movement speed
        if (currentSpeed >= 100)
        {
            currentSpeed = 100;
        }

        // Calculate the new position based on input and speed
        Vector3 move = movement.action.ReadValue<Vector3>() * currentSpeed * Time.deltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(move);

        // Move the Rigidbody to the new position
        rb.MovePosition(newPosition);

        // Update animator parameters based on movement input
        animator.SetFloat("Speed_Up", -moveZ);
        animator.SetFloat("Speed_Down", moveZ);
        animator.SetFloat("Speed_Right", moveX);
        animator.SetFloat("Speed_Left", -moveX);
    }

    // Get the current pointer position
    private Vector3 GetPointerPosition()
    {
        // Get the mouse position from input
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;

        // Convert the screen position to viewport position
        return Camera.main.ScreenToViewportPoint(mousePos);
    }


    // Because the TriggerCheck script is not initialized at the start of the game, we need to wait for it to be found
    private IEnumerator FindTriggerCoroutine()
    {
        yield return new WaitForSeconds(1);
        triggerCheck = GameObject.Find("Trigger").GetComponent<TriggerCheck>();
    }
}
