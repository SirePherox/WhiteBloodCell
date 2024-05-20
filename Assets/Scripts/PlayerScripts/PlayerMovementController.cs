using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [Header("Move Variables")]
    [SerializeField] private float horMoveSpeed = 5.0f;
    [SerializeField] private PlayerInputActions playerInput;
    [SerializeField] private float boundaryXMin ; // Minimum X boundary
    [SerializeField] private float boundaryXMax ;  // Maximum X boundary
    private CharacterController charCont;

    private void Awake()
    {
        charCont = GetComponent<CharacterController>();
        playerInput = new PlayerInputActions();
    }


    private void OnEnable()
    {
        playerInput.Player.TouchSwipe.Enable();
        playerInput.Player.TouchSwipe.performed += x => MovePlayerHorizontalTouch(x.ReadValue<Vector2>()) ;
    }

    private void OnDisable()
    {
        playerInput.Player.TouchSwipe.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerHorizontal();
        ClampHorizontalMovement();
    }

    private void MovePlayerHorizontal()
    {
        float horAxis = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(-(horAxis * horMoveSpeed), 0f, 0f);

        //move
        charCont.Move(moveDir * Time.deltaTime);
    }

    private void MovePlayerHorizontalTouch(Vector2 newVec)
    {
        Vector3 moveDir = new Vector3(-(newVec.x * horMoveSpeed), 0f, 0f); //thee newVec has already been normalized in the input actions preprocessors

        charCont.Move(moveDir * Time.deltaTime);
    }

    private void ClampHorizontalMovement()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundaryXMin, boundaryXMax),
                                         transform.position.y,
                                         transform.position.z);
    }
}
