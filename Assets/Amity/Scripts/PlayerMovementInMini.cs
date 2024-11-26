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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {

        }
    }
}
