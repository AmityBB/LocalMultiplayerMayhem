using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementInMini : MonoBehaviour
{
    private Vector3 moveDir;
    public int speed;
    [SerializeField] private BoxCollider PlayerBlocker;

    private void Start()
    {
        PlayerBlocker.enabled = false;
    }
    private void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        gameObject.GetComponent<Rigidbody>().AddForce(moveDir * speed /** Time.deltaTime*/);
    }
}
