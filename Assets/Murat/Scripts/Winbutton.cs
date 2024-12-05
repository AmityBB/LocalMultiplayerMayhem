using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winbutton : MonoBehaviour
{
    public int killerPick;
    public int roomPick;
    public int weaponPick;
    private WinSystem winSystem;
    private CameraScript cameraScript;

    private void Start()
    {
        winSystem = FindObjectOfType<WinSystem>();
        cameraScript = FindObjectOfType<CameraScript>();
    }
    public void Check()//checkt als je de killer, kamer en wapen heb goed geraden
    {
        if (cameraScript.chosing == 3)
        {
            if (RoomCheck() && WaponCheck() && KillerCheck())
            {
                Debug.Log("you win");
            }
            else
            {
                Debug.Log("you lose");
            }
        }
    }

    private bool KillerCheck()
    {
        if (winSystem.People[killerPick] == winSystem.People[winSystem.killerK])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool RoomCheck()
    {
        if (winSystem.Rooms[roomPick] == winSystem.Rooms[winSystem.roomK])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool WaponCheck()
    {
        if (winSystem.Weapons[weaponPick] == winSystem.Weapons[winSystem.weaponK])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
