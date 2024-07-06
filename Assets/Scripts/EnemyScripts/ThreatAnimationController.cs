using UnityEngine;

public class ThreatAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator threatAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeadAnimation()
    {
        threatAnimator.SetBool(AnimatorTags.THREAT_DEAD, true);
    }
}
