using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillerBehaviour : MonoBehaviour
{
    [SerializeField] private Test gameManager;
    private GameObject NearestPlayer;
    private NavMeshAgent m_agent;

    private void Start()
    {
        gameManager = FindObjectOfType<Test>();
        m_agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        FindNearestPlayer();
        ChasePlayer();
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
        m_agent.SetDestination(NearestPlayer.transform.position);
    }
}
