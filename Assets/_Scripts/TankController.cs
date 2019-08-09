using System;
using UnityEngine;
using UnityEngine.AI;

public class TankController : MonoBehaviour
{
    [SerializeField] private float maxFiringRange = 10.0f;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        SetTarget(GameManager.instance.player.transform.position);
    }

    private void SetTarget(Vector3 targetPosition)
    {
        _agent.destination = targetPosition;
    }
    
}
