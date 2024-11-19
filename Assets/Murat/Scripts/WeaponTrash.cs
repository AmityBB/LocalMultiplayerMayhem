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
    }
    void Update()
    {
        if (!done)
        {
            if (transform.position.y <= 46|| transform.position.y >= 46)
            {
                transform.position = new Vector3(transform.position.x, 46, transform.position.z);
            }
            if (transform.position.z >= 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 2);
            }
            else if(transform.position.z <= -2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -2);
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
                if (gameObject.transform.position.x > 3)
                {
                    getpoints();
                }
                else if (gameObject.transform.position.x < -3)
                {
                    getdeathPoints();
                }
            }
            if (!isTrash)
            {
                if (gameObject.transform.position.x < -3)
                {
                    getpoints();
                }
                else if (gameObject.transform.position.x > 3)
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
                    transform.position = new Vector3(6, 46, 5 + SorteerMinigame.trash.Count*-2.5f);
                    done2 = true;
                }
                else if(!correct)
                {
                    done = false;
                    transform.position = new Vector3(Random.Range(-1,2),46, Random.Range(-1, 2));
                    pickUp = false;
                }
            }
            else
            if (!isTrash)
            {
                if (correct&& !done2)
                {
                    SorteerMinigame.weapons.Add(gameObject);
                    transform.position = new Vector3(-6, 46, 5 + SorteerMinigame.weapons.Count * -2.5f);
                    done2 = true;
                }
                else if(!correct)
                {
                    done = false;
                    transform.position = new Vector3(Random.Range(-1, 2), 46, Random.Range(-1, 2));
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
