using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTriggers : MonoBehaviour
{
    private Test gameManager;
    [SerializeField]
    private int Trigger;

    private void Start()
    {
        gameManager = FindObjectOfType<Test>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (Trigger)
            {
                case 0: other.gameObject.GetComponent<PlayerMovementOnMap>().nearPrint = true; break;
                case 1: other.gameObject.GetComponent<PlayerMovementOnMap>().nearSort  = true; break;
                case 2: other.gameObject.GetComponent<PlayerMovementOnMap>().nearUV    = true; break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (Trigger)
            {
                case 0: 
                    other.gameObject.GetComponent<PlayerMovementOnMap>().nearPrint = false;
                    if (gameManager.PrintActive)
                    {
                        gameManager.PrintMinigame();
                    }
                break;
                case 1: 
                    other.gameObject.GetComponent<PlayerMovementOnMap>().nearSort  = false;
                    if (gameManager.SortingActive)
                    {
                        gameManager.SortingMinigame();
                    }
                break;
                case 2: 
                    other.gameObject.GetComponent<PlayerMovementOnMap>().nearUV    = false;
                    break;
            }
        }
    }
}
