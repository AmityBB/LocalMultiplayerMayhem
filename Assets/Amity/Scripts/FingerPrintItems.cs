using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintItems : MonoBehaviour
{
    [SerializeField]
    private List<Material> materials;
    [SerializeField] private WinSystem gameManager;
    [SerializeField] private Tempbuttonscript temp;

    void Start()
    {
        temp = FindObjectOfType<Tempbuttonscript>();
        gameManager = FindObjectOfType<WinSystem>();
        gameObject.GetComponent<Renderer>().material = materials[gameManager.killerK];
    }
}
