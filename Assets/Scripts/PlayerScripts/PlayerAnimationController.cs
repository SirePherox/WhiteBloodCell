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

    public void WalkAnimBasedOnInput(Vector2 inputVec)
    {
        // Set WalkLeft/Right based on direction (Touch input)
        Debug.Log("move left" + (inputVec.x <= -1.0f));
        Debug.Log("move right" + (inputVec.x >= 1.0f));
        bool isWalkingLeft = inputVec.x <= -1.0f;
        bool isWalkingRight = inputVec.x >= 1.0f;
        animator.SetBool(AnimatorTags.PLAYER_WALK_LEFT, isWalkingLeft); // Update WalkLeft 
        animator.SetBool(AnimatorTags.PLAYER_WALK_RIGHT, isWalkingRight); // Update WalkRight 
    }
}
