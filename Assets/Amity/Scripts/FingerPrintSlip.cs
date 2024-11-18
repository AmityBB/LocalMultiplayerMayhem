using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintSlip : MonoBehaviour
{
    private bool released;
    private bool Checking;
    [SerializeField] private Transform GuessingArea;
    [SerializeField] private int CorrectSlip;
    [SerializeField] private int ThisSlip;

    private void Start()
    {
        /*CorrectSlip = killerpick.killer;*/
    }

    private void OnMouseDown()
    {
        Checking = false;
        released = false;
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
                StartCoroutine(GuessingTimer());
                Checking = true;
            }
        }
    }

    IEnumerator GuessingTimer()
    {
        yield return new WaitForSeconds(1.5f);
        if(ThisSlip == CorrectSlip)
        {
            Debug.Log("Guess correct!");
        }
        else
        {
            Debug.Log("Guess wrong :(");
        }
    }
}
