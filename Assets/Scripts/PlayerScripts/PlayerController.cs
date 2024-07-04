using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(PlayerHealthManager))]
public class PlayerController : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private UIManager uiManager;

    [Space]
    [Header("References")]
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Transform spawnItemsParent; //SpawnManager object

    [Space]
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
        CallImmune,
        Neutral,
    }

    public AttackMechanism currentAttackMechanism = AttackMechanism.Neutral;
    private PlayerHealthManager healthManager;

    private void Awake()
    {
        healthManager = GetComponent<PlayerHealthManager>();
    }

    private void OnEnable()
    {
        uiManager.OnChangeAttackMechanism += OnAttackMechanismChanged;

    }

    private void OnDisable()
    {
        uiManager.OnChangeAttackMechanism -= OnAttackMechanismChanged;
        if (GameStateManager.Instance != null)
        {
            GameStateManager.Instance.OnGameStateChanged -= GameStateChanged;
        }

    }
    // Start is called before the first frame update
    private void Start()
    {
        GameStateManager.Instance.OnGameStateChanged += GameStateChanged;
        currentAttackMechanism = AttackMechanism.Neutral;
    }

    // Update is called once per frame
    private void Update()
    {
        SpawnKillAttackBulletsContinously();
    }

    private void OnAttackMechanismChanged(string newMechanism)
    {
        switch (newMechanism)
        {
            case PlayerAttackTypes.NEUTRAL:
                currentAttackMechanism = AttackMechanism.Neutral;
                break;
            case PlayerAttackTypes.KILL_ATTACK:
                currentAttackMechanism = AttackMechanism.KillAttack;
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                currentAttackMechanism = AttackMechanism.Engulf;
                UseEngulfAttack();
                break;
            case PlayerAttackTypes.WEAKEN_ATTACK:
                currentAttackMechanism = AttackMechanism.Weaken;
                UseWeakenAttack();
                break;
            case PlayerAttackTypes.CALLIMMUNE_ATTACK:
                currentAttackMechanism = AttackMechanism.CallImmune;
                break;
            default:
                Debug.LogWarning("COULDNT HANDLE NEW MECHANISM, DEFAULTING TO KILL ATTACK");
                currentAttackMechanism = AttackMechanism.Neutral;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        BaseThreatController threat;
        if (other.TryGetComponent<BaseThreatController>(out threat))
        {
            switch (threat.threatType)
            {
                case ThreatType.Bacteria:
                    //deal bacteria related damages
                    healthManager.TakeDamage(ThreatTypes.BACTERIA, threat.GetComponent<Bacteria>().damagePower);
                    break;
                case ThreatType.Virus:
                    healthManager.TakeDamage(ThreatTypes.VIRUS, threat.GetComponent<Virus>().damagePower);
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
        newBullet.transform.SetParent(spawnItemsParent,false);
        newBullet.transform.position = bulletSpawnPos.position;
    }
    #endregion


    #region - Attack Mechanisms-
    private void UseEngulfAttack()
    {
        EngulferController engulfer = SpawnManager.Instance.GetEngulfer();
        engulfer.transform.position = bulletSpawnPos.position;
        engulfer.transform.parent = spawnItemsParent;
    }


    private void UseWeakenAttack()
    {
        WeakenerController weakener = SpawnManager.Instance.GetWeakener();
        weakener.transform.position = bulletSpawnPos.position;
        weakener.transform.parent = spawnItemsParent;
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

    private void GameStateChanged(int newState)
    {
        switch (newState)
        {
            case 0: //pause
                currentAttackMechanism = AttackMechanism.Neutral;
                break;
            case 1: //resume
                currentAttackMechanism = AttackMechanism.KillAttack;
                break;
            default:
                Debug.LogWarning("Couldnt handle state changed, setting player attack to neutral");
                currentAttackMechanism = AttackMechanism.Neutral;
                break;

        }
    }
}
