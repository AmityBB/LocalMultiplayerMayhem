using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GeneralButtons : MonoBehaviour
{
    private Test gameManager;
    private Canvas canvas;
    private GameObject inputManager;
    private void Start()
    {
        gameManager = FindObjectOfType<Test>();
        canvas = GetComponentInParent<Canvas>();
        inputManager = FindObjectOfType<PlayerInputManager>().gameObject;
    }
    public void Begin()
    {
        inputManager.SetActive(false);
        gameManager.TitleScreen.GetComponent<Canvas>().enabled = false;
        gameManager.StartRound();
    }
}
