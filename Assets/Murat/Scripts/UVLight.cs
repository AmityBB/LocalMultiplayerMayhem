using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UVLight : MonoBehaviour
{
    public Material reveal;
    public Light light;
    public bool active;
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            light.enabled =true;
            reveal.SetVector("_LightPosition", light.transform.position);
            reveal.SetVector("_LightDirection", -light.transform.forward);
            reveal.SetFloat("_LightAngle", light.spotAngle);
            reveal.SetFloat("_LightStrength", light.range);
        }
        else
        {
            reveal.SetVector("_LightPosition", new Vector4(110, 110, 110, 0));
            reveal.SetVector("_LightDirection", new Vector4(110,110,110,0));
            reveal.SetFloat("_LightAngle", 0);
            reveal.SetFloat("_LightStrength", 0);
            light.enabled = false;
        }

    }
}
