using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour
{
    public RawImage[] playerImages;
    [SerializeField]
    private Test gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<Test>();
    }

    private void Update()
    {
        switch (gameManager.player.Count)
        {
            case 0:
                playerImages[0].enabled = false;
                playerImages[1].enabled = false;
                playerImages[2].enabled = false;
                playerImages[3].enabled = false;
            break;
            case 1:
                playerImages[0].enabled = true;
                playerImages[1].enabled = false;
                playerImages[2].enabled = false;
                playerImages[3].enabled = false;
            break;
            case 2:
                playerImages[0].enabled = true;
                playerImages[1].enabled = true;
                playerImages[2].enabled = false;
                playerImages[3].enabled = false;
                break;
            case 3:
                playerImages[0].enabled = true;
                playerImages[1].enabled = true;
                playerImages[2].enabled = true;
                playerImages[3].enabled = false;
            break;
            case 4:
                playerImages[0].enabled = true;
                playerImages[1].enabled = true;
                playerImages[2].enabled = true;
                playerImages[3].enabled = true;
            break;
        }
    }
}
