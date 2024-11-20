using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementOnMap : MonoBehaviour
{
    private Vector3 MoveDir;
    private Vector3 targetPos;

    public int Stepsleft = 0;
    private bool canMove = true;
    private bool canRoll = true;
    private Test test;
    private WinSystem gameManager;
    [SerializeField] private BoxCollider PlayerBlocker;
    

    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        PlayerBlocker.enabled = true;
        test = FindObjectOfType<Test>();
        this.transform.position = new Vector3(5, 3, -35);
        targetPos = transform.position;
        test.player.Add(this);
    }

    private void Update()
    {
        textMeshProUGUI.text = "Steps:" + Stepsleft.ToString();
        if (Input.GetKeyDown(KeyCode.V) && canRoll)
        {
            DiceRoll();
            canRoll = false;
        }
        this.transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 8);
        if (Vector3.Distance(transform.position, targetPos) < 0.25f)
        {
            this.transform.position = targetPos;
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    public void MyTurn()
    {
        canRoll = true;
    }

    public void DiceRoll()
    {
        Stepsleft += Random.Range(1, 7) + Random.Range(1, 7);
    }

    public void Movement(CallbackContext _context)
    {
        if (_context.performed && Stepsleft > 0 && canMove && gameObject.GetComponent<PlayerMovementOnMap>().enabled)
        {
            if (_context.control.ToString() == "Key:/Keyboard/a" || _context.control.ToString() == "Key:/Keyboard/d")
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
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            RaycastHit Hit;
            if (!Physics.Raycast(transform.position, MoveDir, out Hit, 6))
            {
                transform.rotation = Quaternion.LookRotation(MoveDir);
                if (MoveDir.x > 0) 
                { 
                    MoveDir.x = 10;
                }
                if (MoveDir.x < 0) 
                {
                    MoveDir.x = -10;
                }
                if (MoveDir.z > 0) 
                {
                    MoveDir.z = 10;
                }
                if (MoveDir.z < 0) 
                {
                    MoveDir.z = -10;
                }
                targetPos = this.transform.localPosition + MoveDir;
                Stepsleft--;
            }
        }

        if (_context.canceled)
        {
            if (_context.control.ToString() == "Key:/Keyboard/a" || _context.control.ToString() == "Key:/Keyboard/d")
            {
                MoveDir.x = 0;
            }
            if (_context.control.ToString() == "Key:/Keyboard/w" || _context.control.ToString() == "Key:/Keyboard/s")
            {
                MoveDir.z = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       /* gameManager.getWeapon(collision.gameobject);*/
    }
}
