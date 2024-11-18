using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintSlip : MonoBehaviour
{
    private bool released;
    private bool Checking;
    [SerializeField] private Transform GuessingArea;
    [SerializeField] private int ThisSlip;
    [SerializeField] private tempbuttonscript confirmButton;

    private void OnMouseDown()
    {
        Checking = false;
        released = false;
        confirmButton.Picked = 0;
    }

    private void OnMouseUp()
    {
        released = true;
    }

    void Update()
    {
        if (released)
        {
            if(Vector3.Distance(transform.position,GuessingArea.transform.position) < 1 && !Checking)
            {
                transform.position = new Vector3(GuessingArea.transform.position.x, GuessingArea.transform.position.y,transform.position.z);
                confirmButton.Picked = ThisSlip;
                Checking = true;
            }
        }
    }
}
