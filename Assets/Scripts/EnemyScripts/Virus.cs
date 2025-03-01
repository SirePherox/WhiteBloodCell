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
        
        healthController.OnDamageToXP.AddListener(UpdateSpeedWithXP); //from base class
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(moveSpeed);
    }

    public override void TakeDamage(string playerAttackType, float damageAmount)
    {
        switch (playerAttackType)
        {
            case PlayerAttackTypes.KILL_ATTACK:
                healthController.TakeHealthDamage(damageAmount/damageAmountDivideOffset);
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                healthController.DieInstantly();
                break;
            case PlayerAttackTypes.WEAKEN_ATTACK:
                healthController.TakeXPDamage(damageAmount);
                break;
            default:
                break;
        }
        //the base script contains the IsDead() check, should be called after damage has been done
        base.TakeDamage(playerAttackType, damageAmount);
    }
}
