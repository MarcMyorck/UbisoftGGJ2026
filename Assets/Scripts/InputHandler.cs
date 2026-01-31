using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    PlayerMovement pm;
    Combat c;
    PickupHandler ph;
    SpriteRenderer sr;
    GameManager gm;

    Animator playerAnimator;

    InputAction moveAction;
    InputAction dashAction;
    InputAction attackAction;
    InputAction interact1Action;
    InputAction interact2Action;

    public bool isInteracting = false;
    public float interactTimer = 0f;
    public float interactDelay = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        c = GetComponent<Combat>();
        ph = GetComponent<PickupHandler>();
        sr = GameObject.Find("Player/Sprite").GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerAnimator = GameObject.Find("Player/Sprite").GetComponent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Dash");
        attackAction = InputSystem.actions.FindAction("Attack");
        interact1Action = InputSystem.actions.FindAction("Interact1");
        interact2Action = InputSystem.actions.FindAction("Interact2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gm.isGameOver)
        {
            return;
        }

        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // Movement
        if (moveAction.IsPressed() && interactTimer == 0f)
        {
            pm.MoveHorizontally(moveValue, (c.isAttacking | isInteracting) ? false : dashAction.IsPressed());
            if (moveValue.x > 0)
            {
                sr.flipX = true;
            }
            else
            {
                if (moveValue.x < 0)
                {
                    sr.flipX = false;
                }
            }
            playerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
        }

        if (pm.isDashing)
        {
            playerAnimator.SetBool("IsDashing", true);
        }
        else
        {
            playerAnimator.SetBool("IsDashing", false);
        }

        // Combat
        if (!pm.isDashing && !isInteracting && attackAction.IsPressed() && interactTimer == 0f)
        {
            c.StartAttack(pm.currentDirection);
        }

        if (c.isAttacking)
        {
            playerAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            playerAnimator.SetBool("IsAttacking", false);
        }

        // Interact
        if (!pm.isDashing && !c.isAttacking)
        { 
            if (ph.inside?.Any() == true)
            {
                if (interact1Action.IsPressed() && interact2Action.IsPressed())
                {
                    if (interactTimer == 0f)
                    {
                        isInteracting = true;
                        Gamepad.current.SetMotorSpeeds(2f, 2f);
                        Object.FindFirstObjectByType<CameraShake>().Shake();
                    }
                    interactTimer += Time.deltaTime;
                    if (interactTimer >= interactDelay)
                    {
                        isInteracting = false;
                        Gamepad.current.SetMotorSpeeds(0f, 0f);
                        ph.PickupCombo(ph.GetClosest(gameObject));
                        interactTimer = 0f;
                    }
                }

                if (!(interact1Action.IsPressed() && interact2Action.IsPressed()) && interactTimer > 0f)
                {
                    isInteracting = false;
                    Gamepad.current.SetMotorSpeeds(0f, 0f);
                    Object.FindFirstObjectByType<CameraShake>().StopShake();
                    interactTimer = 0f;
                }
            }
        }

        if (isInteracting)
        {
            playerAnimator.SetBool("IsInteracting", true);
        }
        else
        {
            playerAnimator.SetBool("IsInteracting", false);
        }
    }
}
