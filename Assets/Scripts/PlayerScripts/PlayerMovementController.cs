using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerAnimationController animController;
    private CharacterController charCont;

    [Header("Move Variables")]
    [SerializeField] private float horMoveSpeed = 5.0f;
    [SerializeField] private PlayerInputActions playerInput;
    [SerializeField] private float boundaryXMin ; // Minimum X boundary
    [SerializeField] private float boundaryXMax ;  // Maximum X boundary


    [SerializeField] private Vector2 playerMoveInput;
    private void Awake()
    {
        charCont = GetComponent<CharacterController>();
        playerInput = new PlayerInputActions();
    }


    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs
        MovePlayerHorizontal();
        MovePlayerHorizontal_Touch();

        //Move player
        MovePlayer();
       
    }

   
    private void MovePlayer()
    {
        Vector3 moveKeybaord = MovePlayerHorizontal();
        Vector3 moveTouch = MovePlayerHorizontal_Touch();
        Vector3 movementInputVector = moveKeybaord + moveTouch;

        charCont.Move(movementInputVector * Time.deltaTime);
        ClampHorMovement();
    }

    private Vector3 MovePlayerHorizontal_Touch()
    {
        Vector2 inputVector = playerInput.Player.TouchSwipe.ReadValue<Vector2>();
        inputVector = new(-(inputVector.x * horMoveSpeed), 0.0f);
        Vector3 movementVec = new(inputVector.x, 0.0f, 0.0f);
        return movementVec;
    }


    private Vector3 MovePlayerHorizontal()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        inputVector = new(-(inputVector.x * horMoveSpeed), 0.0f);
        Vector3 movementVec = new(inputVector.x, 0.0f, 0.0f);
        return movementVec;
        
    }


    private void ClampHorMovement()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundaryXMin, boundaryXMax),
                                            transform.position.y, transform.position.z) ;
    }
}
