using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float currentPlayerHealth;
    private float defaultPlayerHealth = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerHealth = defaultPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(string threatType, float damageAmount)
    {
        //TODO Deal specific damage based on threat types
        switch (threatType)
        {
            case ThreatTypes.BACTERIA:
                currentPlayerHealth -= damageAmount;
                break;
            case ThreatTypes.VIRUS:
                currentPlayerHealth -= damageAmount;
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
        return currentPlayerHealth <= 0.0f;
    }
}
