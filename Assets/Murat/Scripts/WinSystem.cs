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

    [SerializeField] private TextMeshProUGUI people;
    [SerializeField] private TextMeshProUGUI rooms;
    [SerializeField] private TextMeshProUGUI weapons;

    [SerializeField] private Image imageKiller;
    [SerializeField] private Image imageRoom;
    [SerializeField] private Image imageWeapon;

    [SerializeField] private List<Sprite> imagePeopleList;
    [SerializeField] private List<Sprite> imageRoomList;
    [SerializeField] private List<Sprite> imageWeaponList;

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
        rand();
    }
    private void rand()//chose who, where and what is the culprit
    {
        killerK = Random.Range(0, People.Count);
        roomK = Random.Range(0, Rooms.Count);
        weaponK = Random.Range(0, Weapons.Count);
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
        people.text = "Person:" + killerChose;
        rooms.text = "room:" + roomChose;
        weapons.text = "weapon:" + weaponChose;
        imageKiller.sprite = imagePeopleList[killerChose];
        imageRoom.sprite = imageRoomList[roomChose];
        imageWeapon.sprite = imageWeaponList[weaponChose];
    }
}


