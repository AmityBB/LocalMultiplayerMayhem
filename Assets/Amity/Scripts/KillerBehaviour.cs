using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillerBehaviour : MonoBehaviour
{
    [SerializeField] private Test gameManager;
    private GameObject NearestPlayer;
    private NavMeshAgent m_agent;
    public float range;
    private bool Roaming;
    private bool TouchingPlayer;
    private Vector3 Destination;
    [SerializeField] private float maxDistance;
    

    private void Start()
    {
        gameManager = FindObjectOfType<Test>();
        m_agent = gameObject.GetComponent<NavMeshAgent>();
        StartCoroutine(Roam());
    }

    private void Update()
    {
        FindNearestPlayer();

        if(Vector3.Distance(NearestPlayer.transform.position, transform.position) < range && !TouchingPlayer)
        {
            Roaming = false;
            ChasePlayer();
        }
        else 
        {
            m_agent.speed = 10;
            Roaming = true; 
        }
    }

    public void FindNearestPlayer()
    {
        float lowestDist = Mathf.Infinity;
        for (int i = 0; i < gameManager.player.Count; i++)
        {
            float dist = Vector3.Distance(gameManager.player[i].transform.position, transform.position);

            if (dist < lowestDist)
            {
                lowestDist = dist;
                NearestPlayer = gameManager.player[i].gameObject;
            }
        }
    }

    public void ChasePlayer()
    {
        m_agent.speed = 18;
        m_agent.SetDestination(NearestPlayer.transform.position);
    }

    IEnumerator Roam()
    {
        yield return new WaitForSeconds(4);

        if (Roaming) 
        {
            Destination = new Vector3(Random.Range(transform.position.x - maxDistance, transform.position.x + maxDistance), transform.position.y - m_agent.baseOffset, Random.Range(transform.position.z - maxDistance, transform.position.z + maxDistance));
            NavMeshPath Path = new();

            if (m_agent.CalculatePath(Destination, Path) && Path.status == NavMeshPathStatus.PathInvalid)
            {
                Debug.Log("path invalid");
            }
            else 
            {
                m_agent.SetPath(Path);
            }
        }
        StartCoroutine(Roam());
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TouchingPlayer = true;
            m_agent.ResetPath();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        TouchingPlayer = false;
    }
}
