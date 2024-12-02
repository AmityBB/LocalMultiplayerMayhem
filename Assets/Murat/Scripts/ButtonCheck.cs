using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    [SerializeField] private int killerPick;
    [SerializeField] private int roomPick;
    [SerializeField] private int weaponPick;



    private WinSystem winSystem;
    private CameraScript cameraScript;
    private Winbutton winButton;
    private void Start()
    {
        winSystem = FindObjectOfType<WinSystem>();
        cameraScript = FindObjectOfType<CameraScript>();
        winButton = FindObjectOfType<Winbutton>();
    }
    public void KillerPick()
    {
        if (cameraScript.chosing==0&& winSystem.canChoos)
        {
            winButton.killerPick = killerPick;
            winSystem.killerChose = killerPick;
            winSystem.choosTime = 0;
            cameraScript.chosing++;
        }
    }
    public void RoomPick()
    {
        if (cameraScript.chosing == 1 && winSystem.canChoos)
        {
            winButton.roomPick = roomPick;
            winSystem.roomChose = roomPick;
            winSystem.choosTime = 0;
            cameraScript.chosing++;
        }
    }
    public void WeaponPick()
    {
        if (cameraScript.chosing == 2 && winSystem.canChoos)
        {
            winButton.weaponPick = weaponPick;
            winSystem.weaponChose = weaponPick;
            winSystem.choosTime = 0;
            cameraScript.chosing++;
        }
    }
    public void TryAgain()
    {
        if (cameraScript.chosing == 3 && winSystem.canChoos)
        {
            cameraScript.chosing = 0;
            winSystem.choosTime = 0;
        }
    }
}

