using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerPrintSlip : MonoBehaviour
{
    [SerializeField] private bool released;
    [SerializeField] private bool Checking;
    [SerializeField] private Transform GuessingArea;
    [SerializeField] private int ThisSlip;
    [SerializeField] private Tempbuttonscript confirmButton;
    [SerializeField] private List<Material> imageList;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = imageList[ThisSlip-1];
    }

    void Update()
    {
        if(GetComponent<MouseDraggingScript>().isDragging)
        {
            Checking = false;
            released = false;
            confirmButton.Picked = 0;
        }
        else
        {
            released = true;
        }
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
