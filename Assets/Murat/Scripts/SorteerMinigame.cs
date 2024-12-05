using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteerMinigame : MonoBehaviour
{
    [SerializeField] private List<GameObject> setWeapons;
    [SerializeField] private List<GameObject> setTrash;
    [SerializeField] private List<GameObject> showWeapon;
    public List<GameObject> weapons;
    public List<GameObject> trash;
    public GameObject table;

    public bool active = false;
    public bool spawn = false;
    private bool done = false;

    private float radius = 0.1f;
    public int points = 0; 
    public int deathPoints = 0;

    WinSystem system;
    private void Start()
    {
        system = FindObjectOfType<WinSystem>();
    }
    void Update()
    {
        if (active)//wanneer je de game speelt
        {
            if (!spawn)//gaat maar een keer
            {
                int x = 0;
                while (x < setTrash.Count)
                {
                    var position = new Vector3(Random.Range(-2.0f, 3.0f) + table.transform.position.x, table.transform.position.y + 1, Random.Range(-3.0f, 3.0f) + table.transform.position.z);
                    Collider[] collider = Physics.OverlapSphere(position, radius);
                    if (collider.Length == 0)
                    {
                        Instantiate(setTrash[x], position, Quaternion.Euler(0,180,0));
                        x += 1;
                    }
                }
                int y = 0;
                while (y < setWeapons.Count)
                {
                    var position = new Vector3(Random.Range(-2.0f, 3.0f) + table.transform.position.x, table.transform.position.y + 1, Random.Range(-3.0f, 3.0f) + table.transform.position.z);
                    Collider[] collider = Physics.OverlapSphere(position, radius);
                    if (collider.Length == 0)
                    {
                        Instantiate(setWeapons[y], position, Quaternion.Euler(0,180,0));
                        y += 1;
                    }
                }
                spawn = true;
            }

            if(points>= setWeapons.Count+ setTrash.Count && !done)
            {
                Instantiate(showWeapon[system.weaponK], new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.Euler(0,-90,-90), this.transform);
                Debug.Log("you win");
                Debug.Log(system.Weapons[system.weaponK]);
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
