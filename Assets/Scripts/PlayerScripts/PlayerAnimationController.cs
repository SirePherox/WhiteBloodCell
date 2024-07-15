using UnityEngine;
using System.Collections;
public class PlayerAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    private PlayerController playerController;
    private GameStateManager gameState;

    private float timeDelay = 3.5f; //appxmtely time needed for the dead animation to finish playing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.OnChangeAttackMechanism.AddListener(ChangeAnimationBasedOnAttackMechanism);

        gameState = GameStateManager.Instance;
        gameState.OnGameSessionEnded.AddListener(PlaySessionEndAnimation);
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

    public void PlaySessionEndAnimation(int sessionEndStatus)
    {
        if (sessionEndStatus == 1)
        {
            //game won
            animator.SetTrigger(AnimatorTags.PLAYER_WIN);
            StartCoroutine(nameof(InvokeSessionEndForWinUI));
        }
        else
        {
            //game lost
            animator.SetTrigger(AnimatorTags.PLAYER_DEAD);
            StartCoroutine(nameof(InvokeSessionEndForFailedUI));
        }
        
    }

    private IEnumerator InvokeSessionEndForWinUI()
    {
        yield return new WaitForSeconds(timeDelay);
        gameState.OnGameSessionEndedUI?.Invoke(1);
    }

    private IEnumerator InvokeSessionEndForFailedUI()
    {
        yield return new WaitForSeconds(timeDelay);
        gameState.OnGameSessionEndedUI?.Invoke(0);
    }
}
