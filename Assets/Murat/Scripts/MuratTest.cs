using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuratTest : MonoBehaviour
{
    private Test test;
    private WinSystem winscript;
    void Start()
    {
        test = FindObjectOfType<Test>();
        winscript = FindObjectOfType<WinSystem>();
        winscript.Players.Add(new PlayerInfo { pos = new Vector3(0, 0, 0), weapons= new List<GameObject>()});
    }
    void Update()
    {
        if (test.player[winscript.playerTurn].Stepsleft<=0)
        {
            test.player[winscript.playerTurn] = FindObjectOfType<PlayerMovementOnMap>();
            test.player[winscript.playerTurn].DiceRoll();
            winscript.doneTurn = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            winscript.getWeapon(collision.gameObject);
        }
        
    }
}
