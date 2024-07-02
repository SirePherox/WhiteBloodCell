using UnityEngine;

public class CapsuleTestScripts : MonoBehaviour
{
    private CharacterController charCont;
    [Header("Move Variables")]
    [SerializeField] private float horMoveSpeed = 5.0f;
    [SerializeField] private PlayerInputActions playerInput;
    [SerializeField] private float boundaryXMin; // Minimum X boundary
    [SerializeField] private float boundaryXMax;  // Maximum X boundary

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        charCont = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerHorizontal();
        ClampHorMovement();
    }

    private void MovePlayerHorizontal()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        inputVector = new(-(inputVector.x * horMoveSpeed), 0.0f);
        charCont.Move(inputVector * Time.deltaTime);

    }

    private void ClampHorMovement()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundaryXMin, boundaryXMax),
                                            transform.position.y, transform.position.z);
    }
}
