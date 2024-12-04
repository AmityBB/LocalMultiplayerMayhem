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

    public GameObject fingerPrintPanel;
    public GameObject bloodPanel;
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
        switch (roomK)
        {
            case 0:
                Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 43), roomBloodPrintPanels[roomK].transform.position.y+0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(0, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 43), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(0, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                break;
            case 1:
                Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 53), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 23)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 53), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 23)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                break;
            case 2:
                int rand3 = Random.Range(1,4);
                switch (rand3)
                {
                    case 0:
                        Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 26), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 26), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        break;
                    case 1:
                        Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(32, 62), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(-7, 13)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(32, 62), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(-7, 13)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        break;
                    case 2:
                        Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(32, 62), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(16, 26)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(32, 62), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(16, 26)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 34), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 21)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 34), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 21)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                break;
            case 4:
                int rand5 = Random.Range(1, 4);
                switch (rand5)
                {
                    case 0:
                        Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 47), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(3, 47), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(3, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        break;
                    case 1:
                        Instantiate(fingerPrintPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(47, 97), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(13, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        Instantiate(bloodPanel, new Vector3(roomBloodPrintPanels[roomK].transform.position.x + Random.Range(47, 97), roomBloodPrintPanels[roomK].transform.position.y + 0.13f, roomBloodPrintPanels[roomK].transform.position.z + Random.Range(13, 33)), Quaternion.Euler(90, Random.Range(0, 360), Random.Range(0, 360)));
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
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


