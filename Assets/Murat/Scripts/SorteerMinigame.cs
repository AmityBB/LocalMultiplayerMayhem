using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteerMinigame : MonoBehaviour
{
    public List<GameObject> weapons;
    public List<GameObject> trash;
    public Camera Cam; 
    public bool active = true;
    public int points = 0; 
    public int deathPoints = 0;
    void Start()
    {
        Cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (active)
        {
            if(points>=5)
            {
                Debug.Log("you win");
            }
            if(deathPoints>=3)
            {
                Debug.Log("you lose");
            }
        }
    }
}
