using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(ThreatHealthController))]
public class BaseThreatController : MonoBehaviour
{
    public ThreatType threatType = ThreatType.Radical;
    public ThreatHealthController healthController;

    /// <summary>
    /// this effects the speed of movement based on the xpRate (currentXp / defaultXp)
    /// such that when xp is full (that's 1) , the multiplier is 1
    /// but if xp reduces , then multiplier is fraction, and speed is also fraction
    /// </summary>
    public float xpSpeedMultiplier = 1.0f; 

   // public ThreatHealthPoint threatHealthPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        healthController = GetComponent<ThreatHealthController>();
        healthController.OnDamageToXP.AddListener(UpdateSpeedWithXP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void MoveForward(float moveSpeed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * (moveSpeed * xpSpeedMultiplier));
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

        //check health after taking damage
        Debug.Log("Checking health");
        CheckToReturnThreatToPool();
    }

    public virtual void Mutate()
    {
        //mutate based on type
    }


    private void CheckToReturnThreatToPool()
    {
        if (healthController.IsThreatDead())
        {
            //return to pool based on threat type
            switch (threatType)
            {
                case ThreatType.Bacteria:
                    SpawnManager.Instance.ReturnBacteriaToPool(this.GetComponent<Bacteria>());
                    Debug.Log("Should clean up here");
                    break;
                case ThreatType.Virus:
                    SpawnManager.Instance.ReturnVirusToPool(this.GetComponent<Virus>());
                    break;
                default:
                    Debug.LogWarning("COULDN'T HANDLE THE THREAT TYPE, OBJECT WASNT RETURNED TO POOL");
                    break;
            }
        }
    }

    private void UpdateSpeedWithXP(float xpRate)
    {
        xpSpeedMultiplier = xpRate;
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
