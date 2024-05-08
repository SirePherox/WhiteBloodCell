using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(ThreatHealthController))]
public class BaseThreatController : MonoBehaviour
{
    public ThreatType threatType = ThreatType.Radical;
    public ThreatHealthController healthController;
    public ThreatHealthPoint threatHealthPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        healthController = GetComponent<ThreatHealthController>();
        if(threatHealthPoint == null)
        {
            Debug.LogWarning("Couldn't GET THE HIT POINT CHILD, TRY REFERENCING IN THE EDITOR");
        }
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

    /// <summary>
    /// In the base damage method, UpdateThreatHealthPoint() &  CheckToReturnThreatToPool()
    /// are already called
    /// </summary>
    /// <param name="playerAttackType"></param>
    /// <param name="damageAmount"></param>
    public virtual void TakeDamage(string playerAttackType, float damageAmount)
    {
        //take damage based on type

        //show visual for taking damage
        UpdateThreatHealthPoint();

        //check health after taking damage
        CheckToReturnThreatToPool();
    }

    public virtual void Mutate()
    {
        //mutate based on type
    }

    public virtual bool IsThreatDead()
    {
        return healthController.current_Health <= 0.0f;
    }

    private void CheckToReturnThreatToPool()
    {
        if (IsThreatDead())
        {
            //return to pool based on threat type
            switch (threatType)
            {
                case ThreatType.Bacteria:
                    SpawnManager.Instance.ReturnBacteriaToPool(this.GetComponent<Bacteria>());
                    break;
                default:
                    Debug.LogWarning("COULDN'T HANDLE THE THREAT TYPE, OBJECT WASNT RETURNED TO POOL");
                    break;
            }
        }
    }

    private void UpdateThreatHealthPoint()
    {
        threatHealthPoint.UpdateHealth(healthController.current_Health);
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
