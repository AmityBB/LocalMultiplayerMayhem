using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBounds : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Killer"))
        {
            collision.gameObject.transform.position = new Vector3(0, collision.transform.position.y, 0);
        }
    }
}
