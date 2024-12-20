using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinSystem : MonoBehaviour
{
    public List<GameObject> People = new List<GameObject>();
    public List<GameObject> Rooms = new List<GameObject>();
    public List<GameObject> Weapons = new List<GameObject>();

    public int killerK;
    public int roomK;
    public int weaponK;

    public int killerChose;
    public int roomChose;
    public int weaponChose;

    [SerializeField] private Image imageKiller;
    [SerializeField] private Image imageRoom;
    [SerializeField] private Image imageWeapon;

    [SerializeField] private List<Image> imageChosePeople;
    [SerializeField] private List<Image> imageChoseRooms;
    [SerializeField] private List<Image> imageChoseWeapons;

    [SerializeField] private List<Sprite> spritePeopleList;
    [SerializeField] private List<Sprite> spriteRoomList;
    [SerializeField] private List<Sprite> spriteWeaponList;

    public List<GameObject> roomBloodPrintPanels;

    public float choosTime = 0;
    public bool canChoos = false;
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
    private void Start()
    {
        Rand();
        for (int i = 0; i < spritePeopleList.Count; i++)
        {
            imageChosePeople[i].sprite = spritePeopleList[i];
            imageChoseRooms[i].sprite = spriteRoomList[i];
            imageChoseWeapons[i].sprite = spriteWeaponList[i];
        }
    }
    private void Rand()//chose who, where and what is the culprit
    {
        killerK = Random.Range(0, People.Count);
        roomK = Random.Range(0, Rooms.Count);
        weaponK = Random.Range(0, Weapons.Count);
        roomBloodPrintPanels[roomK].SetActive(true);
    }
    private void Update()
    {
        if (choosTime > 1.3f)
        {
            canChoos = true;
        }
        else
        {
            canChoos = false;
            choosTime += Time.deltaTime;
        }
        imageKiller.sprite = spritePeopleList[killerChose];
        imageRoom.sprite = spriteRoomList[roomChose];
        imageWeapon.sprite = spriteWeaponList[weaponChose];
    }
}


