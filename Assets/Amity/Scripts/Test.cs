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
    [SerializeField]
    private float scale;

    void Start()
    {
        Cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!Active)
            {
                Cam.transform.rotation = new Quaternion(0, 0, 0, 0);
                clone = Instantiate(MagGlass, Cam.transform.position + (Cam.transform.forward * 5), Quaternion.Euler(-90, 0, 0));
                Active = true;
            }
            else 
            { 
                Cam.transform.rotation = Quaternion.Euler(60, 0, 0);
                Destroy(clone);
                Active = false;
            }
        }
        clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, clone.transform.position.z + Input.mouseScrollDelta.y * scale);
    }
}
