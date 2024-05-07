using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : BaseThreatController
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private 
  
    // Start is called before the first frame update
    void Start()
    {
        threatType = ThreatType.Bacteria;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(moveSpeed);
    }

    public override void TakeDamage(string playerAttackType, float damageAmount)
    {
        base.TakeDamage(playerAttackType,damageAmount);
        switch (playerAttackType)
        {
            case PlayerAttackTypes.KILL_ATTACK:
                healthController.ReduceHealth(damageAmount);
                Debug.Log("A kill attack happened: " + damageAmount);
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                break;
            default:
                break;
        }
    }
}
