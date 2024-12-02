using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public Test gameManager;
    public BoxCollider PlayerBlocker;
    public bool thisTurn;

    public virtual void Start()
    {
        gameManager = FindObjectOfType<Test>();
        gameObject.GetComponent<PlayerMovementOnMap>().enabled = false;
    }
}
