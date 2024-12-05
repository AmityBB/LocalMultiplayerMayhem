using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempbuttonscript : MonoBehaviour
{
    public int Picked;
    public int CorrectSlip;
    [SerializeField] private WinSystem gameManager;
    [SerializeField] private int strikes = 3;

    private void Start()
    {
        gameManager = FindObjectOfType<WinSystem>();
        CorrectSlip = gameManager.killerK + 1;
    }

    public void Confirm()
    {
        if(Picked == CorrectSlip)
        {
            Debug.Log("Win minigame");
        }
        else if(Picked == 0) 
        {
            Debug.Log("Pick first");
        }
        else
        {
            Debug.Log("Lose minigame");
            strikes--;
            if(strikes == 0)
            {
                Destroy(gameManager.gameObject.GetComponent<Test>().player[gameManager.gameObject.GetComponent<Test>().playerWithTurn]);
            }
        }
    }
}
