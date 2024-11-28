using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public List<Transform> KillerSpawns;
    public List<GameObject> player;
    [SerializeField]
    private Camera Cam;
    public bool PrintActive;
    public bool UVActive;
    public bool SortingActive;

    private GameObject clone;
    [SerializeField]
    private GameObject[] Minigames;
    [SerializeField]
    private GameObject Killer;
    public GameObject confirmButton;
    private GameObject inputManager;
    [SerializeField]
    public int playerWithTurn;
    [SerializeField]
    private WeaponTrash[] weaponTrash;
    [SerializeField]
    private Canvas stepsLeftCan;
    public Canvas TitleScreen;
    public Light mainLight;


    void Start()
    {
        Cam = FindObjectOfType<Camera>();
        inputManager = FindObjectOfType<PlayerInputManager>().gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            StartRound();
        }
    }

    public void StartRound()
    {
        stepsLeftCan.GetComponent<Canvas>().enabled = true;
        playerWithTurn = 0;
        for (int i = 0; i < player.Count; i++)
        {
            player[i].GetComponent<PlayerMovementOnMap>().enabled = true;
        }
        player[0].GetComponent<PlayerMovementOnMap>().MyTurn();
    }

    public void TurnEnd()
    {
        player[playerWithTurn].GetComponent<PlayerMovementOnMap>().enabled=false;
        if (playerWithTurn < player.Count - 1)
        {
            playerWithTurn++;
        }
        else
        {
            playerWithTurn = 0;
        }
        player[playerWithTurn].GetComponent<PlayerMovementOnMap>().enabled=true;
        player[playerWithTurn].GetComponent<PlayerMovementOnMap>().MyTurn();
    }

    public void PrintMinigame()
    {
        if (!PrintActive)
        {
            stepsLeftCan.GetComponent<Canvas>().enabled = false;
            Cam.transform.rotation = new Quaternion(0, 0, 0, 0);
            clone = Instantiate(Minigames[0], Cam.transform.position + (Cam.transform.forward * 16), Quaternion.identity);
            PrintActive = true;
            player[playerWithTurn].GetComponent<PlayerMovementOnMap>().canMove = false;
        }
        else
        {
            stepsLeftCan.GetComponent<Canvas>().enabled = true;
            Cam.transform.rotation = Quaternion.Euler(60, 0, 0);
            Destroy(clone);
            PrintActive = false;

            if (player[playerWithTurn].GetComponent<PlayerMovementOnMap>().Stepsleft == 0) { TurnEnd(); }
            else
            {

                player[playerWithTurn].GetComponent<PlayerMovementOnMap>().canMove = true;
            }
        }
    }

    public void UVMinigame()
    {
        if (!UVActive)
        {
            mainLight.intensity = 0.05f;
            stepsLeftCan.GetComponent<Canvas>().enabled = false;
            for (int i = 0; i < player.Count; i++)
            {
                player[i].GetComponent<PlayerMovementOnMap>().enabled = false;
                player[i].GetComponent<PlayerMovementInMini>().enabled = true;
            }
            clone = Instantiate(Killer, KillerSpawns[Random.Range(0, 7)].position, Quaternion.identity);
            StartCoroutine(UVGameTimer());
            UVActive = true;
        }
        else
        {
            mainLight.intensity = 0.8f;
            stepsLeftCan.GetComponent<Canvas>().enabled = true;
            for (int i = 0; i < player.Count; i++)
            {
                player[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                player[i].GetComponent<PlayerMovementOnMap>().enabled = true;
                player[i].GetComponent<PlayerMovementInMini>().enabled = false;
            }
            Destroy(clone);
            UVActive = false;
            StopAllCoroutines();
            if (player[playerWithTurn].GetComponent<PlayerMovementOnMap>().Stepsleft == 0) { TurnEnd(); }
        }
    }

    IEnumerator UVGameTimer()
    {
        yield return new WaitForSecondsRealtime(60);
        UVMinigame();
    }

    public void SortingMinigame()
    {
        if (!SortingActive)
        {
            stepsLeftCan.GetComponent<Canvas>().enabled = false;
            clone = Instantiate(Minigames[1], (Cam.transform.position + new Vector3(0,0,3)) + (Cam.transform.forward * 16), Quaternion.identity);
            clone.GetComponent<SorteerMinigame>().active = true;
            SortingActive = true;
            player[playerWithTurn].GetComponent<PlayerMovementOnMap>().canMove = false;

        }
        else
        {
            stepsLeftCan.GetComponent<Canvas>().enabled = true;
            Destroy(clone);
            Cam.transform.rotation = Quaternion.Euler(60,0,0);
            weaponTrash = FindObjectsOfType(typeof(WeaponTrash)) as WeaponTrash[];
            for (int i = 0; i < weaponTrash.Length; i++)
            {
                Destroy(weaponTrash[i].gameObject);
            }
            SortingActive = false;
            if (player[playerWithTurn].GetComponent<PlayerMovementOnMap>().Stepsleft == 0) { TurnEnd(); }
            else
            {
                player[playerWithTurn].GetComponent<PlayerMovementOnMap>().canMove = true;
            }
        }
    }

    public void CheckPlayer()
    {
        if(player.Count == 0)
        {
            if(UVActive)
            {
                StopAllCoroutines();
                UVMinigame();
                stepsLeftCan.GetComponent<Canvas>().enabled = false;
            }
            inputManager.SetActive(true);
            TitleScreen.GetComponent<Canvas>().enabled = true;
        }
    }

    
}
