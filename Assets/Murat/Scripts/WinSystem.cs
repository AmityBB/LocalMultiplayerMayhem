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

    public int playerTurn = 0;
    public int turns;
    public bool doneTurn = false;

    private static WinSystem instanse;
    private Test test;
    private SorteerMinigame SorteerMinigame;
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
    private void Start()
    {
        SorteerMinigame = FindObjectOfType<SorteerMinigame>();
        //test = FindObjectOfType<Test>();
        for (int i = 0; i < Players.Count; i++)
        {
            test.player[i].enabled = false;
        }
        //test.player[playerTurn].enabled = true;
        rand();
    }
    private void rand()
    {
        killerK = Random.Range(0, People.Count);
        roomK = Random.Range(0, Rooms.Count);
        weaponK = Random.Range(0, Weapons.Count);
    }
    private void next()
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
    public void getWeapon(GameObject weapon)
    {
        if (!Players[playerTurn].weapons.Contains(weapon))
        {
            Players[playerTurn].weapons.Add(weapon);
            weapon.SetActive(false);
            Debug.Log(Players[playerTurn].weapons[0]+"Bark");
        }
        Debug.Log(Players[playerTurn].weapons[0]);

    }
    void GiniGames()
    {
        if (SorteerMinigame.active)
        {
            SorteerMinigame.Cam.transform.position = new Vector3(0, 55, -10); 
            SorteerMinigame.Cam.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
        else
        {
            //cam normal
        }
    }
    private void Update()
    {
        GiniGames();


        //Debug.Log(Players[0].weapons[0]);

        //if (test.player[playerTurn].Stepsleft<=0&& doneTurn)
        //{
        //    next();
        //}
    }
}


