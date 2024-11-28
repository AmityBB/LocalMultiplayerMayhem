using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
