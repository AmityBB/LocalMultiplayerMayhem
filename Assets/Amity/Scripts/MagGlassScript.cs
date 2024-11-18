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
    [SerializeField] 
    private Camera MagView;
    

    private void Start()
    {
        TargetZoom = UnityEngine.Random.Range(-34.01004f, -36.81f);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -36.81f, -34.01004f));
        
        if(Math.Abs(transform.position.z - TargetZoom) < 0.05)
        {
            MagView.GetComponent<PostProcessVolume>().enabled = false;
            StartCoroutine(CorrectZoomTimer());
        }
        else
        {
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
