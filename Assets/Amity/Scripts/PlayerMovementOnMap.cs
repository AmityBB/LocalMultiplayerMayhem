using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementOnMap : MonoBehaviour
{
    private Vector3 MoveDir;
    public int Stepsleft = 0;
    public void Movement(CallbackContext _context)
    {
        if (_context.performed && Stepsleft > 0)
        {
            if(_context.control.ToString() == "Key:/Keyboard/a" || _context.control.ToString() == "Key:/Keyboard/d")
            {
                MoveDir.x = _context.ReadValue<Vector2>().x * 10;
            }
            else
            {
                MoveDir.x = 0;
            }
            if (_context.control.ToString() == "Key:/Keyboard/w" || _context.control.ToString() == "Key:/Keyboard/s")
            {
                MoveDir.z = _context.ReadValue<Vector2>().y * 10;
            }
            else
            {
                MoveDir.z = 0;
            }

            RaycastHit Hit;
            if (Physics.Raycast(transform.position, MoveDir, out Hit, 6))
            {
                Debug.Log(Hit);
            }
            else
            {
                if (MoveDir.x > 0) { MoveDir.x = 10; }
                if (MoveDir.x < 0) { MoveDir.x = -10; }
                if (MoveDir.z > 0) { MoveDir.z = 10; }
                if (MoveDir.z < 0) { MoveDir.z = -10; }
                this.transform.position = this.transform.localPosition + MoveDir;
                Stepsleft--;
            }
        }
    }
}
