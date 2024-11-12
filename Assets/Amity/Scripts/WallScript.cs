using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class WallScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] PlayerTransform;
    [SerializeField]
    private Material m_Material;
    private Color targetColor;
    private Color currentColor;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = gameObject.GetComponent<Renderer>().material;
        currentColor = m_Material.color;
        targetColor = m_Material.color;
        /*PlayerTransform = FindObjectOfType<PlayerMovementOnMap>().gameObject.transform;*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.K))
        {
            for(int i = 0; i < PlayerTransform.Length; i++)
            {
                PlayerTransform[i] = FindObjectOfType<PlayerMovementOnMap>().gameObject.transform;
            }
        }*/
        if (currentColor.a < targetColor.a)
        {
            currentColor.a += 0.01f;
        }
        if( currentColor.a > targetColor.a)
        {
            currentColor.a -= 0.01f;
        }
        for (int i = 0; i < PlayerTransform.Length; i++)
        {
            if (transform.position.x + 5 == PlayerTransform[i].position.x && Vector3.Distance(PlayerTransform[i].position, transform.position) < 10)
            {
                targetColor = new Color(m_Material.color.r, m_Material.color.g, m_Material.color.b, 0.5f);
            }
            else
            {
                targetColor = new Color(m_Material.color.r, m_Material.color.g, m_Material.color.b, 1f);
            }
        }
        m_Material.color = currentColor;
    }
}
