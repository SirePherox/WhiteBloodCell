using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Attack Vars")]
    [SerializeField] private float killAttackAmount = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region - Attack Mechanisms-

    private void KillAttack(BaseEnemyController enemy)
    {
        //normal kill attack
        enemy.TakeDamage(PlayerAttackTypes.KILL_ATTACK, killAttackAmount);
    }
    private void EngulfAttack(BaseEnemyController enemy)
    {
        //specify types it can only engulf
        if(enemy.threatType != ThreatType.Bacteria || enemy.threatType != ThreatType.Virus)
        {
            //engulf mechanics , should also check if its weakened enough
        }
        else
        {
            Debug.Log("Cant engulf this type of enemy");
            //show alert
        }
    }


    private void WeakenAttack(BaseEnemyController enemy)
    {
        //specify types it can only weaken
        if (enemy.threatType != ThreatType.Bacteria || enemy.threatType != ThreatType.Virus)
        {
            //weaken menchanics
        }
        else
        {
            Debug.Log("Cant weaken this type of enemy");
            //show alert
        }
    }

    private void CallImmuneHelp()
    {
        //call for help from immune system
    }

    private void DevelopAntiBodies(BaseEnemyController enemy)
    {
        //develop antibodies for recurring threats
    }
    #endregion
}
