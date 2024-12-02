using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInMini : Player
{
    private Vector3 MoveDir;
    private Vector3 LastMoveDir;
    public int speed;

    public override void Start()
    {
        base.Start();
        PlayerBlocker.enabled = false;
    }
    private void FixedUpdate()
    {
        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (MoveDir == Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(LastMoveDir);
        }
        else
        {
            LastMoveDir = MoveDir;
            transform.rotation = Quaternion.LookRotation(MoveDir);
        }

        gameObject.GetComponent<Rigidbody>().AddForce(MoveDir * speed);
    }

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
