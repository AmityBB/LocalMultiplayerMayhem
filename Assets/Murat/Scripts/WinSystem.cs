using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinSystem : MonoBehaviour
{
    public List<PlayerInfo> Players = new List<PlayerInfo>();

    public List<GameObject> People = new List<GameObject>();
    public List<GameObject> Rooms = new List<GameObject>();
    public List<GameObject> Weapons = new List<GameObject>();

    public int killerK;
    public int roomK;
    public int weaponK;

    private static WinSystem instanse;

    public int playerTurn;
    public int turns;

    Test test;
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
        for (int i = 0; i < Players.Count; i++)
        {
            test.player[i].enabled = false;
        }
        
        rand();
        test = FindObjectOfType<Test>();
    }

    void next()
    {
        Players[playerTurn].pos = test.player[playerTurn].transform.position;
        test.player[playerTurn].enabled = false;
        playerTurn++;
        if (playerTurn > Players.Count)
        {
            playerTurn = 0;
        }
        test.player[playerTurn].enabled = true;
    }
    void getWeapon()
    {
        for (int i = 0;i < Players[playerTurn].weapons.Count; i++)
        {
            if (Players[playerTurn].weapons.Contains(gameObject) == false)
            {
                Players[playerTurn].weapons.Add(gameObject);
            }
        }
    }

    void Update()
    {
        test.player[playerTurn].enabled = true;
        for (int i = playerTurn; i> playerTurn; i++)
        {
            if (playerTurn == i)
            {
                getWeapon();
            }
        }
        
        for (int i = 0; i < Players.Count; i++)
        {
            
        }
    }
    void rand()
    {
        killerK = Random.Range(0, People.Count);
        roomK = Random.Range(0, Rooms.Count);
        weaponK = Random.Range(0, Weapons.Count);
    }
}


