using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementInMini : Player
{
    private float smoothInputSpeed = 0.2f;

    private PlayerInput playerInput;

    private CharacterController controller;

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    private Vector3 MoveDir;
    private Vector3 LastMoveDir;
    public int speed;
    [SerializeField] private InputAction moveAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        moveAction = playerInput.actions["MiniMove"];
    }
    public override void Start()
    {
        base.Start();
        PlayerBlocker.enabled = false;
    }
    private void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);
        Vector3 move = new Vector3(currentInputVector.x, 0, currentInputVector.y);
        controller.Move(move * Time.deltaTime * speed);

        if(input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * speed);
        }
    }
    /*if (MoveDir == Vector3.zero)
    {
        transform.rotation = Quaternion.LookRotation(LastMoveDir);
    }
    else
    {
        LastMoveDir = new Vector3(MoveDir.x , 0, MoveDir.y);
        transform.rotation = Quaternion.LookRotation(new Vector3(MoveDir.x, 0, MoveDir.y));
    }

    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(MoveDir.x, 0, MoveDir.y) * speed);
}

public void Movement(CallbackContext _context)
{
    Debug.Log("aaa");
    if(_context.performed)
    {

        MoveDir = _context.ReadValue<Vector2>().normalized;
    }
    if(_context.canceled)
    {
        MoveDir = Vector3.zero;
    }
}*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            gameManager.player.Remove(this.gameObject);
            gameManager.CheckPlayer();
            if (thisTurn)
            {
                gameManager.TurnEnd();
            }
            Destroy(gameObject);
        }
    }
}