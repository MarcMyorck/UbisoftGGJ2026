using UnityEngine;

public struct AttackComboStruct
{
    public string endpoint; //l for left, r for right
    public float waitTime; //How long to wait before using this attack
    public float attackSpeed; //Attack Speed for this attack

    public AttackComboStruct(string pEndpoint, float pWaitTime, float pAttackSpeed)
    {
        endpoint = pEndpoint;
        waitTime = pWaitTime;
        attackSpeed = pAttackSpeed;
    }
}
