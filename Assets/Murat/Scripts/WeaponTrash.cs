using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrash : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    [SerializeField] private bool isTrash;
    [SerializeField] private bool done= false;
    [SerializeField] private bool done2 = false;
    [SerializeField] private bool correct = false;
    [SerializeField] private bool pickUp = false;
    private SorteerMinigame SorteerMinigame;
    [SerializeField] private GameObject table;
    private void OnMouseDown()
    {
        if (!done)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            pickUp = true;
        }
    }

    private void OnMouseDrag()
    {
        if (!done && pickUp) 
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
    void Start()
    {
        SorteerMinigame = FindObjectOfType<SorteerMinigame>();
        table = GameObject.FindGameObjectWithTag("Table");
    }
    void Update()
    {
        if (!done)
        {
            if (transform.position.y <= table.transform.position.y + 1 || transform.position.y >= table.transform.position.y + 1)
            {
                transform.position = new Vector3(transform.position.x, table.transform.position.y + 1, transform.position.z);
            }
            if (transform.position.z >= 3 + table.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 3 + table.transform.position.z);
            }
            else if(transform.position.z <= -3 + table.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -3 + table.transform.position.z);
            }
        }

        NotDone();
        Done();
    }
    void NotDone()
    {
        if (!done)
        {
            if (isTrash)
            {
                if (gameObject.transform.position.x > 3.5f + table.transform.position.x)
                {
                    getpoints();
                }
                else if (gameObject.transform.position.x < -3.5f + table.transform.position.x)
                {
                    getdeathPoints();
                }
            }
            if (!isTrash)
            {
                if (gameObject.transform.position.x < -3.5f + table.transform.position.x)
                {
                    getpoints();
                }
                else if (gameObject.transform.position.x > 3.5f + table.transform.position.x)
                {
                    getdeathPoints();
                }
            }
        }
    }
    void Done()
    {
        if (done)
        {
            if (isTrash)
            {
                if (correct&& !done2)
                {
                    SorteerMinigame.trash.Add(gameObject);
                    transform.position = new Vector3(6 + table.transform.position.x, table.transform.position.y + 1, 7.5f + SorteerMinigame.trash.Count*-2.5f + table.transform.position.z);
                    done2 = true;
                }
                else if(!correct)
                {
                    done = false;
                    transform.position = new Vector3(Random.Range(-1,2) + table.transform.position.x, table.transform.position.y + 1, Random.Range(-1, 2) + table.transform.position.z);
                    pickUp = false;
                }
            }
            else
            if (!isTrash)
            {
                if (correct&& !done2)
                {
                    SorteerMinigame.weapons.Add(gameObject);
                    transform.position = new Vector3(-6+ table.transform.position.x, table.transform.position.y + 1, 7.5f + SorteerMinigame.weapons.Count * -2.5f + table.transform.position.z);
                    done2 = true;
                }
                else if(!correct)
                {
                    done = false;
                    transform.position = new Vector3(Random.Range(-1, 2) + table.transform.position.x, table.transform.position.y + 1, Random.Range(-1, 2) + table.transform.position.z);
                    pickUp = false;
                }
            }
        }
    }
    void getpoints()
    {
        SorteerMinigame.points++;
        done = true;
        correct = true;
    }
    void getdeathPoints()
    {
        SorteerMinigame.deathPoints++;
        done = true;
        correct = false;
    }
}
