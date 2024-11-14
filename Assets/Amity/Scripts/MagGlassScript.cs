using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class MagGlassScript : MonoBehaviour
{
    [SerializeField]
    private float Distance;
    public float TargetZoom;

    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] 
    private Camera MagView;
    

    private void Start()
    {
        TargetZoom = UnityEngine.Random.Range(-34.01004f, -36.81f);
    }

    private void Update()
    {
        if(transform.position.z > -34.01004)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -34.01004f);
        }
        if(transform.position.z < -36.81)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -36.81f);
        }
        if(Math.Abs(transform.position.z - TargetZoom) < 0.05)
        {
            MagView.GetComponent<PostProcessVolume>().enabled = false;
        }
        else
        {
            MagView.GetComponent<PostProcessVolume>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}
