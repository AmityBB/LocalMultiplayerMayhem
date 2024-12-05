using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class MagGlassScript : MonoBehaviour
{
    [SerializeField]
    private float Distance;
    public float TargetZoom;
    [SerializeField] 
    private Camera MagView;
    [SerializeField]
    private float scale;
    private bool picked = false;
    [SerializeField] private InputAction Scroll;
    private Vector2 ScrollDir;
 

    private void Awake()
    {
        Scroll.Enable();
        Scroll.performed += _context => ScrollDir = _context.ReadValue<Vector2>();
        Scroll.canceled += _context => ScrollDir = Vector2.zero;
    }
    private void Start()
    {
        TargetZoom = UnityEngine.Random.Range(-34.01004f, -36.81f);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -36.81f, -34.01004f));
        if(ScrollDir.y > 1)
        {
            ScrollDir.y =1;
        }
        if (ScrollDir.y < -1)
        {
            ScrollDir.y = -1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + ScrollDir.y * scale);
        ScrollDir.y = 0;
        if (Math.Abs(transform.position.z - TargetZoom) < 0.05)
        {
            if (picked)
            {
                MagView.GetComponent<PostProcessVolume>().enabled = false;
                StartCoroutine(CorrectZoomTimer());
            }
            else
            {
                TargetZoom = UnityEngine.Random.Range(-34.01004f, -36.81f);
            }
        }
        else
        {
            picked = true;
            MagView.GetComponent<PostProcessVolume>().enabled = true;
            StopAllCoroutines();
        }
    }

    IEnumerator CorrectZoomTimer()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Right zoom used, start fingerprint comparison section");
    }
}
