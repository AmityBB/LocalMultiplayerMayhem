using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintItems : MonoBehaviour
{
    [SerializeField]
    private List<Material> materials;
    [SerializeField] private WinSystem gameManager;
    [SerializeField] private tempbuttonscript temp;

    void Start()
    {
        temp = FindObjectOfType<tempbuttonscript>();
        gameManager = FindObjectOfType<WinSystem>();
        gameObject.GetComponent<Renderer>().material = materials[/*gameManager.killerK*/temp.CorrectSlip-1];
    }
}
