using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;

    private float currentMoveSpeed = 10.0f;
    public float moveSpeed = 10.0f;
    public bool isDashing = false;
    public float dashSpeedMultiplier = 2.0f;
    public float dashLength = 0.5f;
    public float currentDashCooldown = 2.0f;
    public float dashCooldown = 2.0f;
    public Vector3 currentDirection = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentDashCooldown < dashCooldown)
        {
            currentDashCooldown += Time.deltaTime;
            if (currentDashCooldown > dashLength)
            {
                currentMoveSpeed = moveSpeed;
                isDashing = false;
            }
        }
    }

    public void MoveHorizontally(Vector2 values, Boolean dash) //X + rechts - links Y + Vor - Zurück
    {
        Vector3 playerVelocity = new Vector3(0, -2f, 0);

        if (dash && currentDashCooldown >= dashCooldown)
        {
            currentMoveSpeed = moveSpeed * dashSpeedMultiplier;
            currentDashCooldown = 0f;
            isDashing = true;
        }

        Vector3 direction = new Vector3(values.x, 0, values.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        //Vector3 targetPosition = (transform.position + (direction * Time.deltaTime * currentMoveSpeed));

        // Move
        Vector3 finalMove = direction * currentMoveSpeed;
        cc.Move(finalMove * Time.deltaTime);

        currentDirection = new Vector3((values.x == 0 ? 0 : values.x / Mathf.Abs(values.x)), 0, (values.y == 0 ? 0 : values.y / Mathf.Abs(values.y)));
    }
}
