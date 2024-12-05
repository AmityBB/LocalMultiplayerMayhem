using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrash : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    [SerializeField] private bool isTrash;
    [SerializeField] public bool done= false;
    [SerializeField] private bool done2 = false;
    [SerializeField] private bool correct = false;
    public bool pickUp = false;
    private SorteerMinigame SorteerMinigame;
    [SerializeField] private GameObject table;

    float extraHeight = 0.5f;
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
        Screanwrap();//om te verkomen dat het van de tafel af komt
        NotDone();//wanneer je niet op de juiste plek heb gezet
        Done();//wanneer je wel op de juiste plek heb gezet
    }
    void Screanwrap()
    {
        float extraDist = 3.5f;
        if (!done)
        {
            if (transform.position.y <= table.transform.position.y + extraHeight || transform.position.y >= table.transform.position.y + extraHeight)
            {
                transform.position = new Vector3(transform.position.x, table.transform.position.y + extraHeight, transform.position.z);
            }
            if (transform.position.z >= extraDist + table.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, extraDist + table.transform.position.z);
            }
            else if (transform.position.z <= -extraDist + table.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -extraDist + table.transform.position.z);
            }
        }
    }
    void NotDone()
    {
        float checkSides = 3.5f;
        if (!done)
        {
            if (isTrash)
            {
                if (gameObject.transform.position.x > checkSides + table.transform.position.x)
                {
                    Getpoints();
                }
                else if (gameObject.transform.position.x < -checkSides + table.transform.position.x)
                {
                    GetdeathPoints();
                }
            }
            if (!isTrash)
            {
                if (gameObject.transform.position.x < -checkSides + table.transform.position.x)
                {
                    Getpoints();
                }
                else if (gameObject.transform.position.x > checkSides + table.transform.position.x)
                {
                    GetdeathPoints();
                }
            }
        }
    }
    void Done()
    {
        float doneSide = 4;
        float correctDist = 4.5f;
        float correctExtraDist = 1.5f;
        if (done)
        {
            if (isTrash)
            {
                if (correct&& !done2)
                {
                    SorteerMinigame.trash.Add(gameObject);
                    transform.position = new Vector3(doneSide + table.transform.position.x, table.transform.position.y + extraHeight, correctDist + SorteerMinigame.trash.Count*-correctExtraDist + table.transform.position.z);
                    done2 = true;
                    GetComponent<MouseDraggingScript>().isDragging = false;
                }
                else if(!correct)
                {
                    done = false;
                    transform.position = new Vector3(Random.Range(-1,2) + table.transform.position.x, table.transform.position.y + extraHeight, Random.Range(-1, 2) + table.transform.position.z);
                    pickUp = false;
                    GetComponent<MouseDraggingScript>().isDragging = false;
                }
            }
            else
            if (!isTrash)
            {
                if (correct&& !done2)
                {
                    SorteerMinigame.weapons.Add(gameObject);
                    transform.position = new Vector3(-doneSide + table.transform.position.x, table.transform.position.y + extraHeight, correctDist + SorteerMinigame.weapons.Count * -correctExtraDist + table.transform.position.z);
                    done2 = true;
                    GetComponent<MouseDraggingScript>().isDragging = false;
                }
                else if(!correct)
                {
                    done = false;
                    transform.position = new Vector3(Random.Range(-1, 2) + table.transform.position.x, table.transform.position.y + extraHeight, Random.Range(-1, 2) + table.transform.position.z);
                    pickUp = false;
                    GetComponent<MouseDraggingScript>().isDragging = false;
                }
            }
        }
    }
    void Getpoints()//je krijgt winpunten
    {
        SorteerMinigame.points++;
        done = true;
        correct = true;
    }
    void GetdeathPoints()//je krijgt verliespunten
    {
        SorteerMinigame.deathPoints++;
        done = true;
        correct = false;
    }
}
