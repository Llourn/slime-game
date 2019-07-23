using UnityEngine;
using UnityEngine.AI;

public class FindSafety : MonoBehaviour
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
        if (Vector3.Distance(slime.position, this.transform.position) < 10.0f)
        {
            agent.destination = target.position;
            flee = true;
        }

        if (Vector3.Distance(transform.position, agent.destination) < 1f & flee)
        {
            agent.isStopped = true;
        }

    }

    private void SelectTarget()
    {
        float distance = Mathf.Infinity;

        for(int i = 0; i < GameManager.instance.hidingSpotManager.hidingSpots.Count; i++)
        {
            float t = Vector3.Distance(this.transform.position, GameManager.instance.hidingSpotManager.hidingSpots[i].position);
            if (t < distance) target = GameManager.instance.hidingSpotManager.hidingSpots[i];
        }
    }
}
