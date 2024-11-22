using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInMini : MonoBehaviour
{
    private Vector3 MoveDir;
    private Vector3 LastMoveDir;
    public int speed;
    [SerializeField] private BoxCollider PlayerBlocker;

    private void Start()
    {
        PlayerBlocker.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
                LastMoveDir = MoveDir;  
        }

        if (!Input.GetKeyUp(KeyCode.W) && !Input.GetKeyUp(KeyCode.A) && !Input.GetKeyUp(KeyCode.S) && !Input.GetKeyUp(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (MoveDir == Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(LastMoveDir);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(MoveDir);
        }

        gameObject.GetComponent<Rigidbody>().AddForce(MoveDir * speed);
    }
}
