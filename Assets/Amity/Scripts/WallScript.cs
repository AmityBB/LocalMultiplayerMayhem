using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class WallScript : MonoBehaviour
{
    [SerializeField]
    private Material m_Material;
    private Color targetColor;
    private Color currentColor;
    private Test test;
    private bool PlayerNear;
    // Start is called before the first frame update
    void Start()
    {
        test = FindObjectOfType<Test>();
        m_Material = gameObject.GetComponent<Renderer>().material;
        currentColor = m_Material.color;
        targetColor = m_Material.color;
        /*PlayerTransform = FindObjectOfType<PlayerMovementOnMap>().gameObject.transform;*/
    }

    // Update is called once per frame
    void Update()
    {
        
                
        if (currentColor.a < targetColor.a)
        {
            currentColor.a += 0.01f;
        }
        if( currentColor.a > targetColor.a)
        {
            currentColor.a -= 0.01f;
        }


        if (PlayerNear)
        {
            targetColor = new Color(m_Material.color.r, m_Material.color.g, m_Material.color.b, 0.5f);
        }
        else 
        { 
            targetColor = new Color(m_Material.color.r, m_Material.color.g, m_Material.color.b, 1f);
        }
        
        m_Material.color = currentColor;
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerNear = true;
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerNear = false;
    }
}
