using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(EnemyHealthController))]
public class BaseThreatController : MonoBehaviour
{
    public ThreatType threatType = ThreatType.Radical;
    public EnemyHealthController healthController;
    // Start is called before the first frame update
    void Start()
    {
        healthController = GetComponent<EnemyHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void MoveForward(float moveSpeed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    public virtual void Attack()
    {
        //attack base on type
    }

    public virtual void TakeDamage(string playerAttackType, float damageAmount)
    {
        //die based on die type
    }

    public virtual void Mutate()
    {
        //mutate based on type
    }
}

//[Serializable]
public enum ThreatType
{
    Bacteria,
    Virus,
    Toxin,
    Radical
}
