using UnityEngine;

public struct AttackComboStruct
{
    public string endpoint; //l for right to left, r for left to right, m for middle only
    public float waitTime; //How long to wait before using this attack
    public float attackSpeed; //Attack Speed for this attack

    public AttackComboStruct(string pEndpoint, float pWaitTime, float pAttackSpeed)
    {
        endpoint = pEndpoint;
        waitTime = pWaitTime;
        attackSpeed = pAttackSpeed;
    }
}
