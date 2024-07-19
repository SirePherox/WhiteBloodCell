using UnityEngine;

public class Toxin : BaseThreatController
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 5.0f;
    public float damagePower = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        threatType = ThreatType.Toxin;

        healthController.OnDamageToXP.AddListener(UpdateSpeedWithXP); //from base class
    }

    // Update is called once per frame
    private void Update()
    {
        MoveForward(moveSpeed);
    }

    public override void TakeDamage(string playerAttackType, float damageAmount)
    {
        switch (playerAttackType)
        {
            case PlayerAttackTypes.KILL_ATTACK:
                healthController.TakeHealthDamage(damageAmount);
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                healthController.DieInstantly();
                break;
            case PlayerAttackTypes.WEAKEN_ATTACK:
                healthController.TakeXPDamage(damageAmount);
                break;
            default:
                break;
        }
        //the base script contains the IsDead() check, should be called after damage has been done
        base.TakeDamage(playerAttackType, damageAmount);
    }
}
