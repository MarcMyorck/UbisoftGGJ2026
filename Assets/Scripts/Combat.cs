using UnityEngine;

public class Combat : MonoBehaviour
{
    public string comboName = "Ghost";
    public AttackComboStruct[] combo;
    public int currentComboStep = 0;
    public bool isAttacking = false;
    public GameObject damageZone;
    public float damageZoneDistance = 1.0f;
    public float attackTime = 0f;
    public float waitTimer = 0f;

    public Vector3 rotated45left;
    public Vector3 rotated45right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AssignAttackCombo();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAttacking)
        {
            if (waitTimer >= combo[currentComboStep].waitTime)
            {
                attackTime += Time.deltaTime * combo[currentComboStep].attackSpeed;

                // Clamp t
                attackTime = Mathf.Clamp01(attackTime);

                // Interpolate direction along the curve
                Vector3 curvedDir = Vector3.zero;
                if (combo[currentComboStep].endpoint == "l")
                {
                    curvedDir = Vector3.Slerp(rotated45right, rotated45left, attackTime);
                }
                else
                {
                    if (combo[currentComboStep].endpoint == "r")
                    {
                        curvedDir = Vector3.Slerp(rotated45left, rotated45right, attackTime);
                    }
                    else
                    {
                        if (combo[currentComboStep].endpoint == "m")
                        {
                            curvedDir = Vector3.Slerp(rotated45left, rotated45right, 0.5f);
                        }
                    }
                }

                // Move object along that curved direction
                damageZone.transform.position = transform.position + curvedDir * damageZoneDistance;

                if (attackTime >= 1f)
                {
                    if (currentComboStep + 1 == combo.Length)
                    {
                        damageZone.transform.position = transform.position;
                        isAttacking = false;
                        attackTime = 0f;
                        Vector3 rotated45left = Vector3.zero;
                        Vector3 rotated45right = Vector3.zero;
                        currentComboStep = 0;
                        waitTimer = 0f;
                    } 
                    else
                    {
                        attackTime = 0f;
                        currentComboStep++;
                        waitTimer = 0f;
                    }
                }
            }
            else
            {
                waitTimer += Time.deltaTime;
            }
        }
    }

    public void StartAttack(Vector3 currentDirection)
    {
        if (!isAttacking)
        {
            isAttacking = true;

            Vector3 forward = currentDirection.normalized;
            float angleL = 45f * Mathf.Deg2Rad;
            float cosL = Mathf.Cos(angleL);
            float sinL = Mathf.Sin(angleL);
            rotated45left = new Vector3(forward.x * cosL - forward.z * sinL, 0, forward.x * sinL + forward.z * cosL);

            float angleR = -45f * Mathf.Deg2Rad;
            float cosR = Mathf.Cos(angleR);
            float sinR = Mathf.Sin(angleR);
            rotated45right = new Vector3(forward.x * cosR - forward.z * sinR, 0, forward.x * sinR + forward.z * cosR);

            damageZone.transform.position = transform.position + rotated45left;
        }
    }

    public void AssignAttackCombo()
    {
        switch (comboName)
        {
            case "Ghost":
                combo = new AttackComboStruct[]{
                    new AttackComboStruct("m", 0f, 1.0f)
                };
                break;
            case "Knight":
                combo = new AttackComboStruct[]{
                    new AttackComboStruct("r", 0f, 2.0f),
                    new AttackComboStruct("l", 0.5f, 3.0f),
                    new AttackComboStruct("r", 0.25f, 2.5f)
                }; 
                break;
        }
    }
}
