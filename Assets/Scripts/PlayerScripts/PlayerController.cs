using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(PlayerHealthManager))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Transform spawnItemsParent; //SpawnManager object

    [Header("Attack Vars")]
    [SerializeField] private float killAttackAmount = 5.0f;
    private float killAttackBulletFireRate = 2.0f;
    private float nextFireTime = 0.0f;
    [Serializable]
    public enum AttackMechanism
    {
        KillAttack,
        Engulf,
        Weaken,
        CallImmune
    }

    public AttackMechanism currentAttackMechanism = AttackMechanism.KillAttack;
    private PlayerHealthManager healthManager;

    private void Awake()
    {
        healthManager = GetComponent<PlayerHealthManager>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        SpawnKillAttackBulletsContinously();
    }


    private void OnTriggerEnter(Collider other)
    {
        BaseThreatController threat;
        if(other.TryGetComponent<BaseThreatController>(out threat))
        {
            switch (threat.threatType)
            {
                case ThreatType.Bacteria:
                    //deal bacteria related damages
                    healthManager.TakeDamage(ThreatTypes.BACTERIA, threat.GetComponent<Bacteria>().damagePower);
                    break;
                default:
                    Debug.LogWarning("COULDN'T HANDLE THIS THREAT TYPE, CANT DEAL DAMAGE TO PLAYER");
                    break;

              
            }


        }
    }

    #region -Kill Attack Bullets
    private void SpawnKillAttackBulletsContinously()
    {
        if (currentAttackMechanism != AttackMechanism.KillAttack)
            return;

        if (Time.time > nextFireTime)
        {
            SpawnKillAttackBullets();
            nextFireTime = Time.time + 1f / killAttackBulletFireRate; // Update next fire time based on fire rate
        }
    }

    private void SpawnKillAttackBullets()
    {
            BulletController newBullet = SpawnManager.Instance.GetKillAttackBullet();
            newBullet.transform.position = bulletSpawnPos.position;
            newBullet.transform.parent = spawnItemsParent;
    }
    #endregion

    #region - Attack Mechanisms-

    private void KillAttack(BaseThreatController enemy)
    {
        //normal kill attack
        enemy.TakeDamage(PlayerAttackTypes.KILL_ATTACK, killAttackAmount);
    }
    private void EngulfAttack(BaseThreatController enemy)
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


    private void WeakenAttack(BaseThreatController enemy)
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

    private void DevelopAntiBodies(BaseThreatController enemy)
    {
        //develop antibodies for recurring threats
    }
    #endregion
}
