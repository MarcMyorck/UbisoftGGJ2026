using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    PlayerMovement pm;
    Combat c;
    PickupHandler ph;

    InputAction moveAction;
    InputAction jumpAction;
    InputAction attackAction;
    InputAction interactAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        c = GetComponent<Combat>();
        ph = GetComponent<PickupHandler>();

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // Movement
        if (moveAction.IsPressed())
        {
            pm.MoveHorizontally(moveValue, jumpAction.IsPressed());
        }

        // Combat
        if (attackAction.IsPressed())
        {
            c.StartAttack(pm.currentDirection);
        }

        // Interact
        if (interactAction.IsPressed())
        {
            ph.PickupCombo(ph.GetClosest(gameObject));
        }
    }
}
