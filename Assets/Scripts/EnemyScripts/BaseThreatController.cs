using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(ThreatHealthController))]
[RequireComponent(typeof(ThreatAnimationController))]
public class BaseThreatController : MonoBehaviour
{
    public ThreatType threatType = ThreatType.Radical;
    public ThreatHealthController healthController;
    public ThreatAnimationController animationController;

    /// <summary>
    /// this effects the speed of movement based on the xpRate (currentXp / defaultXp)
    /// such that when xp is full (that's 1) , the multiplier is 1
    /// but if xp reduces , then multiplier is fraction, and speed is also fraction
    /// </summary>
    public float xpSpeedMultiplier = 1.0f;
    public float currentMoveSpeed;
    // public ThreatHealthPoint threatHealthPoint;

    // Start is called before the first frame update
    void Start()
    {
        healthController = GetComponent<ThreatHealthController>();
        animationController = GetComponent<ThreatAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void MoveForward(float moveSpeed)
    {
        currentMoveSpeed = moveSpeed * xpSpeedMultiplier;
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
        CheckToReturnToPool();
    }

    public virtual void Mutate()
    {
        //mutate based on type
    }

    private void CheckToReturnToPool()
    {
        if (gameObject.activeInHierarchy)
        {
            if (healthController.IsThreatDead())
            {
                StartCoroutine(CheckToReturnThreatToPool());
            }
        }

    }
    private IEnumerator CheckToReturnThreatToPool()
    {
        // Play the death animation
        animationController.PlayDeadAnimation();

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

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

    public void UpdateSpeedWithXP(float xpRate)
    {
        Debug.Log("recieved Sednig the event..");
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
