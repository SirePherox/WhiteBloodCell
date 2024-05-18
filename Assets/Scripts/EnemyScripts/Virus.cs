using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : BaseThreatController
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 4.0f;
    public float damagePower = 5.0f;

    [Header("Attack Variables")]
    private float damageAmountDivideOffset = 1.5f; 
    // Start is called before the first frame update
    void Start()
    {
        threatType = ThreatType.Virus;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(moveSpeed);
    }

    public override void TakeDamage(string playerAttackType, float damageAmount)
    {
        base.TakeDamage(playerAttackType, damageAmount);
        switch (playerAttackType)
        {
            case PlayerAttackTypes.KILL_ATTACK:
                healthController.TakeDamage(damageAmount/damageAmountDivideOffset);
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                break;
            default:
                break;
        }
    }
}
