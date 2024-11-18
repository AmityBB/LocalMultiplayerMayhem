using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<PlayerMovementOnMap> player;
    [SerializeField]
    private GameObject MagGlass;
    private Camera Cam;
    private bool Active;
    private GameObject clone;
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
        if( Input.GetKeyDown(KeyCode.Alpha3))
        {
            SortingMinigame();
        }
    }

    private void PrintMinigame()
    {
        if (!Active)
        {
            Cam.transform.rotation = new Quaternion(0, 0, 0, 0);
            clone = Instantiate(MagGlass, Cam.transform.position + (Cam.transform.forward * 5), Quaternion.Euler(-90, 0, 0));
            confirmButton.SetActive(true);
            Active = true;
        }
        else
        {
            Cam.transform.rotation = Quaternion.Euler(60, 0, 0);
            Destroy(clone);
            confirmButton.SetActive(false);
            Active = false;
        }
    }

    private void UVMinigame()
    {

    }

    private void SortingMinigame()
    {

    }
}
