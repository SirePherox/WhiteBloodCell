using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : BaseThreatController
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 5.0f;
     //public float bacteriaDefaultHealth;
     public float damagePower = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        threatType = ThreatType.Bacteria;
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(moveSpeed);
       // bacteriaCurrentHealth = healthController.current_Health;
    }

    public override void TakeDamage(string playerAttackType, float damageAmount)
    {
        switch (playerAttackType)
        {
            case PlayerAttackTypes.KILL_ATTACK:
                healthController.TakeDamage(damageAmount);
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                healthController.DieInstantly();
                break;
            default:
                break;
        }
        //the base script contains the IsDead() check, should be called after damage has been done
        base.TakeDamage(playerAttackType, damageAmount);
    }
}
