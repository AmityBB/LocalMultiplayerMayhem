using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown killerDropdown;
    [SerializeField] private TMP_Dropdown roomDropdown;
    [SerializeField] private TMP_Dropdown weaponDropdown;

    [SerializeField] private Image imageKiller;
    [SerializeField] private Image imageRoom;
    [SerializeField] private Image imageWeapon;

    [SerializeField] private List<Sprite> imagePeopleList;
    [SerializeField] private List<Sprite> imageRoomList;
    [SerializeField] private List<Sprite> imageWeaponList;

    WinSystem winSystem;
    private void Start()
    {
        winSystem = FindObjectOfType<WinSystem>();
    }
    private void Update()
    {
        imageKiller.sprite = imagePeopleList[killerDropdown.value];
        imageRoom.sprite = imageRoomList[roomDropdown.value];
        imageWeapon.sprite = imageWeaponList[weaponDropdown.value];
    }
    public void Check()
    {
        /*
        if (RoomCheck())
        {
            //corret roomK
        }
        else
        {
            //incorret roomK
        }

        if (WaponCheck())
        {
            //corret weaponK
        }
        else
        {
            //incorret weaponK
        }

        if (KillerCheck())
        {
            //corret person
        }
        else
        {
            //incorret person
        }
        */
        if (RoomCheck() && WaponCheck() && KillerCheck())
        {
            Debug.Log("you win");
        }
        else
        {
            Debug.Log("you lose");
        }
    }

    private bool KillerCheck()
    {
        if (winSystem.People[killerDropdown.value] == winSystem.People[winSystem.killerK])
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
        if (winSystem.Rooms[roomDropdown.value] == winSystem.Rooms[winSystem.roomK])
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
        if (winSystem.Weapons[weaponDropdown.value] == winSystem.Weapons[winSystem.weaponK])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

