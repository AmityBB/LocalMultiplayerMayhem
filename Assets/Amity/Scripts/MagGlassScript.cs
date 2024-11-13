using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagGlassScript : MonoBehaviour
{
    [SerializeField]
    private float Distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 point = new Vector3();
            Vector2 mousePos = new Vector2();

            mousePos.x = Input.mousePosition.x;
            mousePos.y = Camera.main.pixelHeight/10 + Input.mousePosition.y;

            point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100))
            {
                gameObject.transform.position = point + (Camera.main.transform.forward * Distance);
            }
        }
    }
}
