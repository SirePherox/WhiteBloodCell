using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    private PlayerController playerController;

    private void Awake()
    {
       // animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.OnChangeAttackMechanism.AddListener(ChangeAnimationBasedOnAttackMechanism);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnimationBasedOnAttackMechanism(string newAttackMech)
    {
        switch (newAttackMech)
        {
            case PlayerAttackTypes.KILL_ATTACK:
                animator.SetBool(AnimatorTags.KILL_ATTACK, true);
                break;
            case PlayerAttackTypes.NEUTRAL:
                animator.SetBool(AnimatorTags.KILL_ATTACK, false);
                break;
            case PlayerAttackTypes.ENGULF_ATTACK:
                animator.SetBool(AnimatorTags.KILL_ATTACK, false);
                animator.SetTrigger(AnimatorTags.ENGULF_ATTACK);
                break;
            case PlayerAttackTypes.WEAKEN_ATTACK:
                animator.SetBool(AnimatorTags.KILL_ATTACK, false);
                animator.SetTrigger(AnimatorTags.WEAKEN_ATTACK);
                break;
            default:
                Debug.LogWarning("COULDN'T HANDLE ATTACK MECHANISM. CORRECT ANIIMATION WON'T PLAY");
                break;
        }
    }
}
