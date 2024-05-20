using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Variables")]
    private float _currentPlayerHealth;
    private float defaultPlayerHealth = 100.0f;

    /// <summary>
    /// Returns the currenthealth divided by the defaultHealth
    /// </summary>
    public float currentPlayerHealthRate
    {
        get
        {
            return _currentPlayerHealth / defaultPlayerHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentPlayerHealth = defaultPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(string threatType, float damageAmount)
    {
        //show vfx


        //TODO Deal specific damage based on threat types
        switch (threatType)
        {
            case ThreatTypes.BACTERIA:
                _currentPlayerHealth -= damageAmount;
                break;
            case ThreatTypes.VIRUS:
                _currentPlayerHealth -= damageAmount;
                break;
            default:
                Debug.LogWarning("COULDNT HANDLE THE THREATTYPE, CANT DEAL DAMAGE TO PLAYER HEALTH");
                break;
        }

        CheckIsPlayerDeadGameOver();
    }

    public void Heal(float healAmount)
    {

    }

    public void CheckIsPlayerDeadGameOver()
    {
        if (IsPlayerDead())
        {
            //game over
            Debug.Log("Game over with player death");
        }
    }
    private bool IsPlayerDead()
    {
        return _currentPlayerHealth <= 0.0f;
    }
}
