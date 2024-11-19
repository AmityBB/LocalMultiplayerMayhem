using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteerMinigame : MonoBehaviour
{
    [SerializeField] private List<GameObject> setWeapons;
    [SerializeField] private List<GameObject> setTrash;
    public List<GameObject> weapons;
    public List<GameObject> trash;
    public Camera Cam; 
    public bool active = true;
    private bool spawn = false;
    private float radius = 0.5f;
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
            if (!spawn)
            {
                int x = 0;
                while (x < setTrash.Count)
                {
                    var position = new Vector3(Random.Range(-3.0f, 3.0f), 46, Random.Range(-3.0f, 3.0f));
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
                    var position = new Vector3(Random.Range(-3.0f, 3.0f), 46, Random.Range(-3.0f, 3.0f));
                    Collider[] collider = Physics.OverlapSphere(position, radius);
                    if (collider.Length == 0)
                    {
                        Instantiate(setWeapons[y], position, Quaternion.identity);
                        y += 1;
                    }
                }
                //for (int i = 0; i < setWeapons.Count; i++)
                //{
                //    GameObject temp;
                //    temp = Instantiate(setWeapons[i], new Vector3(Random.Range(-2.0f, 2.0f), 46,Random.Range(-2.0f,2.0f)) , Quaternion.identity);
                //    temp = Instantiate(setTrash[i], new Vector3(Random.Range(-2.0f, 2.0f), 46, Random.Range(-2.0f, 2.0f)), Quaternion.identity);
                //}
                spawn = true;
            }

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
