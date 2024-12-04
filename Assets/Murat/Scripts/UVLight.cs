using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UVLight : MonoBehaviour
{
    public List<Material> reveal;
    public Light light;
    public bool active;
    Test gameMaster;
    // Update is called once per frame
    private void Start()
    {
        gameMaster = FindObjectOfType<Test>();
    }
    void Update()
    {
        if (gameMaster.UVActive)
        {
            light.enabled =true;
            for (int i = 0; i < reveal.Count; i++)//zorgt foor de UV 
            {
                reveal[i].SetVector("_LightPosition", light.transform.position);
                reveal[i].SetVector("_LightDirection", -light.transform.forward);
                reveal[i].SetFloat("_LightAngle", light.spotAngle);
                reveal[i].SetFloat("_LightStrength", light.range);
            }
        }
        else
        {
            for (int i = 0; i < reveal.Count; i++)//zorgt dat het uit is
            {
                reveal[i].SetVector("_LightPosition", new Vector4(110, 110, 110, 0));
                reveal[i].SetVector("_LightDirection", new Vector4(110, 110, 110, 0));
                reveal[i].SetFloat("_LightAngle", 0);
                reveal[i].SetFloat("_LightStrength", 0);
            }
            light.enabled = false;
        }

    }
}
