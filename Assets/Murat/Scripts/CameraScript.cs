using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    private SorteerMinigame sorteer;
    private Test gameMaster;

    [SerializeField] private GameObject m_Map;

    public int chosing;
    public float camSpeed = 15;
    private bool nearMinigame = false;

    public bool playerTime;
    public bool guessing;
    [SerializeField] private List<GameObject> gesScreens;
    private bool done = false;
   

    void Start()
    {
        gameMaster = FindObjectOfType<Test>();
    }

    void Update()
    {
        if (!guessing)
        {
            done = false;
        }
        if (gameMaster.player.Count != 0)
        {
            if (!gameMaster.player[gameMaster.playerWithTurn].GetComponent<PlayerMovementOnMap>().nearPrint
            && !gameMaster.player[gameMaster.playerWithTurn].GetComponent<PlayerMovementOnMap>().nearSort
            && !gameMaster.player[gameMaster.playerWithTurn].GetComponent<PlayerMovementOnMap>().nearUV)
            {
                nearMinigame = false;
            }
            else
            {
                nearMinigame = true;
            }
        }
        if (guessing)
        {
            float hight = 10f;
            float distZ = -2;
            if (!done)
            {
                m_Camera.transform.position = new Vector3(gesScreens[0].transform.position.x, gesScreens[0].transform.position.y + hight, gesScreens[0].transform.position.z + distZ);
                m_Camera.transform.rotation = Quaternion.Euler(80, 0, 0);
                done = true;
            }
            if (chosing == 0)
            {
                camSpeed = 100;
            }
            else
            {
                camSpeed = 15;
            }
            m_Camera.transform.position = Vector3.MoveTowards(m_Camera.transform.position, new Vector3(gesScreens[chosing].transform.position.x, gesScreens[chosing].transform.position.y + hight, gesScreens[chosing].transform.position.z + distZ), camSpeed * Time.deltaTime);
        }
        else if (gameMaster.SortingActive)//sorteer minigame
        {
            sorteer = FindObjectOfType<SorteerMinigame>();
            m_Camera.transform.position = new Vector3(sorteer.table.transform.position.x, sorteer.table.transform.position.y + 10, sorteer.table.transform.position.z);
            m_Camera.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        else if (gameMaster.PrintActive)//fingerprint minigame
        {
            //m_Camera.transform.position = new Vector3(m_Printgame.transform.position.x, m_Printgame.transform.position.y, m_Printgame.transform.position.z - 16);
            m_Camera.transform.position = new Vector3(m_Map.transform.position.x, m_Map.transform.position.y + 90, m_Map.transform.position.z + -37);
            m_Camera.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        else if (gameMaster.UVActive)//kamer minigame
        {
            m_Camera.transform.position = new Vector3(m_Map.transform.position.x, m_Map.transform.position.y + 90, m_Map.transform.position.z + -45);
            m_Camera.transform.rotation = Quaternion.Euler(60, 0, 0);
        }
        else if(gameMaster.player.Count != 0 && !nearMinigame)
        {
            if (gameMaster.player[gameMaster.playerWithTurn].GetComponent<PlayerMovementOnMap>().thisTurn) //de spelers buirt
            {
                m_Camera.transform.position = new Vector3(gameMaster.player[gameMaster.playerWithTurn].transform.position.x, gameMaster.player[gameMaster.playerWithTurn].transform.position.y + 23, gameMaster.player[gameMaster.playerWithTurn].transform.position.z - 20);
                m_Camera.transform.rotation = Quaternion.Euler(45, 0, 0);
            }
        }
        else//laat de hele map zien
        {
            m_Camera.transform.position = new Vector3(m_Map.transform.position.x, m_Map.transform.position.y + 90, m_Map.transform.position.z + -45);
            m_Camera.transform.rotation = Quaternion.Euler(60, 0, 0);
        }
    }
}
