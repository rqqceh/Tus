using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;

    bool isRightHanded = true;

    private TusInputAction controls;
    
    private Vector3 turnInput = Vector3.zero;
    private Vector2 moveInput = Vector2.zero;
    private bool jumpInput = false;
    
    // Use this for initialization
    void Awake()
    {
        controls = new TusInputAction();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void PlayerMove(Vector2 move)
    {
        moveInput = move;
    }

    void PlayerTurn(Vector3 turnInput)
    {

    }

    void OnEnable()
    {
        controls.Enable();
        if (isRightHanded)
        {
            controls.PlayerControl_RightHanded.Move.performed += ctx => PlayerMove(ctx.ReadValue<Vector2>());
            controls.PlayerControl_RightHanded.Move.canceled += ctx => moveInput = Vector2.zero;
        }
        else
        {
            controls.PlayerControl_LeftHanded.Move.performed += ctx => PlayerMove(ctx.ReadValue<Vector2>());
            controls.PlayerControl_LeftHanded.Move.canceled += ctx => moveInput = Vector2.zero;
        }
    }

    void OnDisable()
    {
        
    }
}
