﻿using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    public Transform target;
    public Transform slime;
    private NavMeshAgent agent;
    private bool flee;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        if(Vector3.Distance(slime.position, this.transform.position) < 10.0f)
        {
            agent.destination = target.position;
            flee = true;
        }

        if(Vector3.Distance(transform.position, agent.destination) < 0.5f & flee)
        {
            agent.isStopped = true;
        }
        
    }
}