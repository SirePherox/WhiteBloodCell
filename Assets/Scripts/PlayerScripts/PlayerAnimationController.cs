using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;

    private void Awake()
    {
       // animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkAnimBasedOnInput(bool isMovingLeft)
    {
        // Set WalkLeft/Right based on direction (Touch input)
        Debug.Log("move vctor" + isMovingLeft);
        animator.SetBool(AnimatorTags.PLAYER_WALK_LEFT, isMovingLeft); // Update WalkLeft 
        animator.SetBool(AnimatorTags.PLAYER_WALK_RIGHT, !isMovingLeft); // Update WalkRight 
    }
}
