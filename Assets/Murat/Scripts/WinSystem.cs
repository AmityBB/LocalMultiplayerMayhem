using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> Rooms = new List<GameObject>();
    [SerializeField] private List<GameObject> Weapons = new List<GameObject>();
    [SerializeField] private List<GameObject> People = new List<GameObject>();

    [SerializeField] private int roomK;
    [SerializeField] private int killerK;
    [SerializeField] private int weaponK;

    public int chosenRoom = -1;
    public int chosenKiller = -1;
    public int chosenWeapon = -1;

    private static WinSystem instanse;
    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject); 
    }
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
        weaponK = Random.Range(0, Weapons.Count);
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
        if (Weapons[chosenWeapon] == Weapons[weaponK])
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
