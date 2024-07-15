using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("References")]
    private PlayerController playerController;
    private SoundController soundContrl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        playerController.OnChangeAttackMechanism.AddListener(ChangeSoundBasedOnAttackMechanics);

        soundContrl = SoundController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSoundBasedOnAttackMechanics(string newAttackMech)
    {
        switch (newAttackMech)
        {
            case PlayerAttackTypes.NEUTRAL:
                soundContrl.PlayNeutralAttack();
                break;
            case PlayerAttackTypes.KILL_ATTACK:
                soundContrl.PlayKillAttack();
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                soundContrl.PlayEngulfAttack();
                break;
            case PlayerAttackTypes.WEAKEN_ATTACK:
                soundContrl.PlayWeakenAttack();
                break;
            default:
                soundContrl.PlayNeutralAttack();
                Debug.LogWarning("COULDN'T HANDLE ATTACK MECHANISM. CORRECT SOUND WON'T PLAY");
                break;
        }
    }
}
