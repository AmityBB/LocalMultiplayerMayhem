using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    SorteerMinigame sorteer;
    void Start()
    {
        m_Camera = GetComponent<Camera>();
        sorteer = FindObjectOfType<SorteerMinigame>();
    }

    void Update()
    {
        if (sorteer.active)
        {
            m_Camera.transform.position = new Vector3(sorteer.table.transform.position.x, sorteer.table.transform.position.y + 10, -10 + sorteer.table.transform.position.z);
            m_Camera.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
        else
        {

        }

    }
}
