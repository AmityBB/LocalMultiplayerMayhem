using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementOnMap : Player
{
    private Vector3 MoveDir;
    private Vector3 targetPos;

    public int Stepsleft = 0;
    public bool canMove = true;
    [SerializeField]
    public bool canRoll = false;
    public bool nearPrint;
    public bool nearSort;
    public bool nearUV;
    public bool moving;
    
    private LayerMask layerMask;
    public GameObject ColorSpot;

    public TextMeshProUGUI textMeshProUGUI;

    public override void Start()
    {
        base.Start();
        gameManager.player.Add(gameObject);
        layerMask = LayerMask.GetMask("Player");
        PlayerBlocker.enabled = true;
        switch (gameManager.player.Count)
        {
            case 1: this.transform.position = new Vector3(5, 3.2f, -35);
                ColorSpot.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2: this.transform.position = new Vector3(-5, 3.2f, -35);
                ColorSpot.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 3: this.transform.position = new Vector3(-5, 3.2f, -25);
                ColorSpot.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 4: this.transform.position = new Vector3(5, 3.2f, -25);
                ColorSpot.GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
        
        targetPos = transform.position;
        textMeshProUGUI = GameObject.Find("Stepsleft").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (thisTurn)
        {
            textMeshProUGUI.text = "Steps:" + Stepsleft.ToString();
        }


        this.transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 8);

        if (Vector3.Distance(transform.position, targetPos) < 0.25f && !gameManager.SortingActive && !gameManager.PrintActive)
        {
            this.transform.position = targetPos;
            canMove = true;
            moving = false;
        }
        else
        {
            moving = true;
            canMove = false;
        }
        if (Stepsleft == 0 && !nearPrint && !nearSort && !nearUV && thisTurn && !canRoll && !moving)
        {
            thisTurn = false;
            gameManager.TurnEnd();
        }
    }


    public void MyTurn()
    {
        canRoll = true;
        thisTurn = true;
    }

    

    public void Select(CallbackContext _context)
    {
        if(_context.performed)
        {
            if (nearPrint)
            {
                gameManager.PrintMinigame();
            }
            if (nearSort)
            {
                gameManager.SortingMinigame();
            }
            if (nearUV)
            {
                gameManager.UVMinigame();
            }
            if (gameManager.UVActive && Stepsleft == 0)
            {
                gameManager.TurnEnd();
            }
        }
    }
    public void RollDice(CallbackContext _context)
    {
        if (canRoll)
        {
            Stepsleft += Random.Range(1, 7) + Random.Range(1, 7);
            canRoll = false;
        }
    }


    public void Movement(CallbackContext _context)
    {
        if (_context.performed && Stepsleft > 0 && canMove && gameObject.GetComponent<PlayerMovementOnMap>().enabled && gameManager.UVActive == false)
        {
            Debug.Log(_context);
            if (_context.ReadValue<Vector2>().x != 0)
            {
                MoveDir.x = _context.ReadValue<Vector2>().x * 10;
            }
            else
            {
                MoveDir.x = 0;
            }

            if (_context.ReadValue<Vector2>().y != 0)
            {
                MoveDir.z = _context.ReadValue<Vector2>().y * 10;
            }
            else
            {
                MoveDir.z = 0;
            }

            if (!Physics.Raycast(transform.position, MoveDir, 6, ~layerMask))
            {
                /*transform.rotation = Quaternion.LookRotation(MoveDir);*/

                if (MoveDir.x > 0)
                {
                    if (MoveDir.z == 0)
                    {
                        MoveDir.x = 10;
                    }
                    else
                    {
                        MoveDir.z = 0;
                        MoveDir.x = 0;
                    }
                }

                if (MoveDir.x < 0)
                {
                    if (MoveDir.z == 0)
                    {
                        MoveDir.x = -10;
                    }
                    else
                    {
                        MoveDir.z = 0;
                        MoveDir.x = 0;
                    }
                }

                if (MoveDir.z > 0)
                {
                    if (MoveDir.x == 0)
                    {
                        MoveDir.z = 10;
                    }
                    else
                    {
                        MoveDir.z = 0;
                        MoveDir.x = 0;
                    }
                }

                if (MoveDir.z < 0)
                {
                    if (MoveDir.x == 0)
                    {
                        MoveDir.z = -10;
                    }
                    else
                    {
                        MoveDir.z = 0;
                        MoveDir.x = 0;
                    }
                }

                targetPos = this.transform.localPosition + MoveDir;
                Stepsleft--;
            }
            else
            {
                Debug.Log("can't move");
            }
            transform.rotation = Quaternion.LookRotation(MoveDir);
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
}
