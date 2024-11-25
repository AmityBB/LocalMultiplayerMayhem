using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrint : MonoBehaviour
{
    [SerializeField] private bool isLight;
    [SerializeField] private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (isLight)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Light")
        {
            isLight = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            isLight = false;
        }
    }
}
