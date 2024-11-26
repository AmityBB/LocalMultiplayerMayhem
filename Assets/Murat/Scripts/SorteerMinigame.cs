using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteerMinigame : MonoBehaviour
{
    [SerializeField] private List<GameObject> setWeapons;
    [SerializeField] private List<GameObject> setTrash;
    public List<GameObject> weapons;
    public List<GameObject> trash;
    public GameObject table;
    public bool active = false;
    private bool spawn = false;
    private bool done = false;
    private float radius = 0.3f;
    public int points = 0; 
    public int deathPoints = 0;
    void Update()
    {
        if (active)
        {
            if (!spawn)
            {
                int x = 0;
                while (x < setTrash.Count)
                {
                    var position = new Vector3(Random.Range(-3.0f, 3.0f) + table.transform.position.x, table.transform.position.y + 1, Random.Range(-3.0f, 3.0f) + table.transform.position.z);
                    Collider[] collider = Physics.OverlapSphere(position, radius);
                    if (collider.Length == 0)
                    {
                        Instantiate(setTrash[x], position, Quaternion.identity);
                        x += 1;
                    }
                }
                int y = 0;
                while (y < setWeapons.Count)
                {
                    var position = new Vector3(Random.Range(-3.0f, 3.0f) + table.transform.position.x, table.transform.position.y + 1, Random.Range(-3.0f, 3.0f) + table.transform.position.z);
                    Collider[] collider = Physics.OverlapSphere(position, radius);
                    if (collider.Length == 0)
                    {
                        Instantiate(setWeapons[y], position, Quaternion.identity);
                        y += 1;
                    }
                }
                spawn = true;
            }

            if(points>= setWeapons.Count+ setTrash.Count && !done)
            {
                Debug.Log("you win");
                done = true;
            }
            if(deathPoints>=3 && !done)
            {
                Debug.Log("you lose");
                done = true;
            }
        }
    }
}
