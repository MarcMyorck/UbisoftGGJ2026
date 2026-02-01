using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    PlayerMovement pm;
    Combat c;
    PickupHandler ph;
    SpriteRenderer sr;
    SpriteRenderer srFace;
    GameManager gm;
    SoundeffectManager sm;

    Animator playerAnimator;

    InputAction moveAction;
    InputAction dashAction;
    InputAction attackAction;
    InputAction interact1Action;
    InputAction interact2Action;

    public bool isInteracting = false;
    public float interactTimer = 0f;
    public float interactDelay = 3.0f;

    public float interactCooldownTimer = 3.0f;
    public float interactCooldown = 3.0f;

    public GameObject objectToPickUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        c = GameObject.Find("Player").GetComponent<Combat>();
        ph = GetComponent<PickupHandler>();
        sr = GameObject.Find("Player/Sprite").GetComponent<SpriteRenderer>();
        srFace = GameObject.Find("Player/Face").GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sm = GameObject.Find("SoundeffectManager").GetComponent<SoundeffectManager>();

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
                srFace.flipX = true;
            }
            else
            {
                if (moveValue.x < 0)
                {
                    sr.flipX = false;
                    srFace.flipX = false;
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
        if (interactCooldownTimer < interactCooldown)
        {
            interactCooldownTimer += Time.deltaTime;
        }

        if (interactCooldownTimer >= interactCooldown)
        {
            if (playerAnimator.GetBool("IsInteractingBackwards") == true)
            {
                playerAnimator.SetBool("IsInteractingBackwards", false);
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.3f, GameObject.Find("Player/Sprite").transform.position.z);
            }
            if (interact1Action.IsPressed() && interact2Action.IsPressed() && c.comboName != "Ghost")
            {
                ph.RevertCombo();
                interactCooldownTimer = 0f;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 2.3f, GameObject.Find("Player/Sprite").transform.position.z);
            }
            else
            {
                if (!pm.isDashing && !c.isAttacking && c.comboName == "Ghost")
                {
                    if (ph.inside?.Any() == true)
                    {
                        if (interact1Action.IsPressed() && interact2Action.IsPressed())
                        {
                            if (interactTimer == 0f)
                            {
                                sm.PlayInteractSound();
                                objectToPickUp = ph.GetClosest(gameObject);
                                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 2.3f, GameObject.Find("Player/Sprite").transform.position.z);
                                isInteracting = true;
                                if (Gamepad.current != null)
                                {
                                    Gamepad.current.SetMotorSpeeds(2f, 2f);
                                }
                                Object.FindFirstObjectByType<CameraShake>().Shake();
                            }
                            interactTimer += Time.deltaTime;
                            if (interactTimer >= interactDelay)
                            {
                                sm.StopInteractSound();
                                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.3f, GameObject.Find("Player/Sprite").transform.position.z);
                                isInteracting = false;
                                if (Gamepad.current != null)
                                {
                                    Gamepad.current.SetMotorSpeeds(0f, 0f);
                                }
                                ph.PickupCombo(objectToPickUp);
                                interactTimer = 0f;
                                interactCooldownTimer = 0f;
                            }
                        }

                        if (!(interact1Action.IsPressed() && interact2Action.IsPressed()) && interactTimer > 0f)
                        {
                            sm.StopInteractSound();
                            GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.3f, GameObject.Find("Player/Sprite").transform.position.z);
                            isInteracting = false;
                            if (Gamepad.current != null)
                            {
                                Gamepad.current.SetMotorSpeeds(0f, 0f);
                            }
                            Object.FindFirstObjectByType<CameraShake>().StopShake();
                            interactTimer = 0f;
                        }
                    }
                }
                else
                {
                    if (isInteracting)
                    {
                        sm.StopInteractSound();
                        GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.3f, GameObject.Find("Player/Sprite").transform.position.z);
                        isInteracting = false;
                        if (Gamepad.current != null)
                        {
                            Gamepad.current.SetMotorSpeeds(0f, 0f);
                        }
                        Object.FindFirstObjectByType<CameraShake>().StopShake();
                        interactTimer = 0f;
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

        if (!(interact1Action.IsPressed() && interact2Action.IsPressed()) && isInteracting && playerAnimator.GetBool("IsInteracting"))
        {
            sm.StopInteractSound();
            GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.3f, GameObject.Find("Player/Sprite").transform.position.z);
            isInteracting = false;
            if (Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(0f, 0f);
            }
            Object.FindFirstObjectByType<CameraShake>().StopShake();
            interactTimer = 0f;
            playerAnimator.SetBool("IsInteracting", false);
        }
    }
}
