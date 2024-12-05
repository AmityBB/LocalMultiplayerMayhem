using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{

    public static Test Instance { get; private set; }

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
    
    public bool GameStarted;

    public event EventHandler OnGameDeviceChanged;

    public enum GameDevice
    {
        KeyboardMouse,
        Gamepad,
    }


    
    private GameDevice activeGameDevice;
    private void Awake()
    {
        Instance = this;
        

        InputSystem.onActionChange += InputSystem_OnActionChange;
    }

    private void InputSystem_OnActionChange(object arg1, InputActionChange inputActionChange)
    {
        if(inputActionChange == InputActionChange.ActionPerformed && arg1 is InputActionChange)
        {
            InputAction inputAction = arg1 as InputAction;
            if (inputAction.activeControl.device.displayName == "VirtualMouse")
            {
                return;
            }
            if(inputAction.activeControl.device is Gamepad)
            {
                if(activeGameDevice != GameDevice.Gamepad)
                {
                    ChangeActiveGameDevice(GameDevice.Gamepad);
                }
            }
            else
            {
                if(activeGameDevice != GameDevice.KeyboardMouse)
                {
                    ChangeActiveGameDevice(GameDevice.KeyboardMouse);
                }
            }
        }
    }

    private void ChangeActiveGameDevice(GameDevice activeGameDevice)
    {
        this.activeGameDevice = activeGameDevice;

        Cursor.visible = activeGameDevice == GameDevice.KeyboardMouse;

        OnGameDeviceChanged?.Invoke(this, EventArgs.Empty);
    }

    public GameDevice GetActiveGameDevice()
    {
        return activeGameDevice;
    }

    void Start()
    {
        Cam = FindObjectOfType<Camera>();
        inputManager = FindObjectOfType<PlayerInputManager>().gameObject;
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
        GameStarted = true;
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
            Cam.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            clone = Instantiate(Minigames[0], Cam.transform.position + (Cam.transform.forward * 16), Quaternion.Euler(90,0,0));
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
            clone = Instantiate(Killer, KillerSpawns[UnityEngine.Random.Range(0, 7)].position, Quaternion.identity);
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
            Cam.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            stepsLeftCan.GetComponent<Canvas>().enabled = false;
            clone = Instantiate(Minigames[1], (Cam.transform.position + new Vector3(0,0,3)) + (Cam.transform.forward * 16), Quaternion.identity);
            clone.GetComponent<SorteerMinigame>().active = true;
            SortingActive = true;
            player[playerWithTurn].GetComponent<PlayerMovementOnMap>().canMove = false;

        }
        else
        {
            Cam.transform.rotation = Quaternion.Euler(60f, 0f, 0f);
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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            TitleScreen.GetComponent<Canvas>().enabled = true;
            GameStarted = false;
        }
    }

    
}
