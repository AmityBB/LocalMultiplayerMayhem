using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<PlayerMovementOnMap> player;
    [SerializeField]
    private GameObject MagGlass;
    private Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        Cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(MagGlass, Cam.transform.position + (Cam.transform.forward * 4), Quaternion.Euler(-30,0,0));
        }
    }
}
