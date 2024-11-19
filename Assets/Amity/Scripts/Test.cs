using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<PlayerMovementOnMap> player;
    [SerializeField]
    private Camera Cam;
    private bool Active;
    private GameObject clone;
    [SerializeField]
    private GameObject[] Minigames;
    public GameObject confirmButton;

    void Start()
    {
        Cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PrintMinigame();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            UVMinigame();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SortingMinigame();
        }
    }

    private void PrintMinigame()
    {
        if (!Active)
        {
            Cam.transform.rotation = new Quaternion(0, 0, 0, 0);
            clone = Instantiate(Minigames[0], Cam.transform.position + (Cam.transform.forward * 16), Quaternion.identity);
            Active = true;
        }
        else
        {
            Cam.transform.rotation = Quaternion.Euler(60, 0, 0);
            Destroy(clone);
            Active = false;
        }
    }

    private void UVMinigame()
    {
        if (!Active)
        {
            for (int i = 0; i < player.Count; i++)
            {
                player[i].GetComponent<PlayerMovementOnMap>().enabled = false;
                player[i].GetComponent<PlayerMovementInMini>().enabled = true;
            }
            Active = true;
        }
        else
        {
            for (int i = 0; i < player.Count; i++)
            {
                player[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                player[i].GetComponent<PlayerMovementOnMap>().enabled = true;
                player[i].GetComponent<PlayerMovementInMini>().enabled = false;
            }
            Active = false;
        }
    }

    private void SortingMinigame()
    {

    }
}
