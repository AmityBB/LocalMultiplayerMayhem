using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDraggingScript : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    [SerializeField]
    private InputAction press, screenPos;

    private Vector3 curScreenPos;

    Camera cam;
    public bool isDragging;

    [SerializeField]
    private GameObject virtualMouse;
    [SerializeField]
    private bool isOnSortItem;
    private Vector3 WorldPos
    {
        get
        {
            float z = cam.WorldToScreenPoint(transform.position).z;
            return cam.ScreenToWorldPoint(curScreenPos + new Vector3(0, 0, z));
        }
    }
    private bool isClickedOn
    {
        get
        {
            Ray ray = cam.ScreenPointToRay(curScreenPos);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                return hit.transform == transform;
            }
            return false;
        }
    }

    private void Awake()
    {
        virtualMouse = FindObjectOfType<VirtualCursorUI>().gameObject;
        cam = Camera.main;
        screenPos.Enable();
        press.Enable();
        screenPos.performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
        press.performed += _ => { if (isOnSortItem) { if (GetComponent<WeaponTrash>().done == false) { if (isClickedOn) isDragging = true; StartCoroutine(Drag()); GetComponent<WeaponTrash>().pickUp = true; } } else { if (isClickedOn) isDragging = true; StartCoroutine(Drag()); } };
        press.canceled += _ => { isDragging = false; };
    }
   

    private IEnumerator Drag()
    {
        if (isOnSortItem)
        {
            if (GetComponent<WeaponTrash>().done == false && GetComponent<WeaponTrash>().pickUp == true)
            {
                
                Vector3 offset = transform.position - WorldPos;
                while (isDragging)
                {
                    transform.position = WorldPos + offset;
                    yield return null;
                }
            }
        }
        else{
            isDragging = true;
            Vector3 offset = transform.position - WorldPos;
            while (isDragging)
            {
                transform.position = WorldPos + offset;
                yield return null;
            }
        }
    }

}
