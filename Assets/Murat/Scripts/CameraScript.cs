using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private GameObject m_Map;
    [SerializeField] private GameObject m_Printgame;
    SorteerMinigame sorteer;
    bool kamer;
    [SerializeField] private bool print;
    public bool playerTime;
    private int playerWithTurn;
    Test gameMaster;
    void Start()
    {
        m_Camera = GetComponent<Camera>();
        gameMaster = FindObjectOfType<Test>();
        sorteer = FindObjectOfType<SorteerMinigame>();
    }

    void Update()
    {
        if (sorteer.active)
        {
            m_Camera.transform.position = new Vector3(sorteer.table.transform.position.x, sorteer.table.transform.position.y + 10, -10 + sorteer.table.transform.position.z);
            m_Camera.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
        else if (kamer)
        {

        }
        else if (print)
        {
            m_Camera.transform.position = new Vector3(m_Printgame.transform.position.x, m_Printgame.transform.position.y, m_Printgame.transform.position.z - 15);
            m_Camera.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (playerTime)
        {
            m_Camera.transform.position = new Vector3(gameMaster.player[playerWithTurn].transform.position.x, gameMaster.player[playerWithTurn].transform.position.y + 10, gameMaster.player[playerWithTurn].transform.position.z - 10);
            m_Camera.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
        else
        {
            m_Camera.transform.position = new Vector3(m_Map.transform.position.x, m_Map.transform.position.y+ 90, m_Map.transform.position.z+ -45);
            m_Camera.transform.rotation = Quaternion.Euler(60, 0, 0);
        }
    }
}
