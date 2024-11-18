using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempbuttonscript : MonoBehaviour
{
    public int Picked;
    [SerializeField] private int CorrectSlip;
   /* private WinSystem gameManager;*/

    private void Start()
    {
        /*CorrectSlip = gameManager.killer;*/
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
        }
    }
}
