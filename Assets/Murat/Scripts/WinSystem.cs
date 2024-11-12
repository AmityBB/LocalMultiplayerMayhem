using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> Rooms = new List<GameObject>();
    [SerializeField] private List<GameObject> Wapons = new List<GameObject>();
    [SerializeField] private List<GameObject> People = new List<GameObject>();
    private int roomK;
    private int killerK;
    private int waponK;
    public int chosenRoom;
    public int chosenKiller;
    public int chosenWapon;
    void Start()
    {
        rand();
    }

    void Update()
    {
        
    }
    void rand()
    {
        roomK = Random.Range(0, Rooms.Count);
        killerK = Random.Range(0, People.Count);
        waponK = Random.Range(0, Wapons.Count);
    }
    public void Check()
    {
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
            //corret waponK
        }
        else
        {
            //incorret waponK
        }

        if (KillerCheck())
        {
            //corret person
        }
        else
        {
            //incorret person
        }

        if (RoomCheck()&& WaponCheck() && KillerCheck())
        {
            //you win
        }else
        {
            //you lose
        }
    }

    bool RoomCheck()
    {
        if (Rooms[chosenRoom] == Rooms[roomK])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool WaponCheck()
    {
        if (Wapons[chosenWapon] == Wapons[waponK])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool KillerCheck()
    {
        if (People[chosenKiller] == People[killerK])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
