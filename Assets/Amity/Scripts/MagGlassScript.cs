using System;
using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
        TargetZoom = UnityEngine.Random.Range(-34.01004f, -36.81f);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -36.81f, -34.01004f));
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Input.mouseScrollDelta.y * scale);
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
