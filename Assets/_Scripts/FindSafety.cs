using UnityEngine;
using UnityEngine.AI;

public class FindSafety : MonoBehaviour
{
    public Transform target;
    private  Transform slime;
    private NavMeshAgent agent;
    private bool isHidden = false;
    private bool isEaten = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        slime = GameManager.instance.player.transform;
    }

    private void Update()
    {
        if (isEaten) return;

        if (Vector3.Distance(slime.position, this.transform.position) < 10.0f && !isHidden)
        {
            SelectTarget();
        }

        if (Vector3.Distance(transform.position, agent.destination) < 0.2f & isHidden)
        {
            agent.isStopped = true;
        }
    }

    private void SelectTarget()
    {
        if (isEaten) return;
        Debug.Log("SELECT TARGET");
        float distance = Mathf.Infinity;


        for(int i = 0; i < GameManager.instance.hidingSpotManager.hidingSpots.Count; i++)
        {
            IsTheHidingSpotBetweenMeAndTheSlime(GameManager.instance.hidingSpotManager.hidingSpots[i].position);
            float t = Vector3.Distance(this.transform.position, GameManager.instance.hidingSpotManager.hidingSpots[i].position);
            if (t < distance) target = GameManager.instance.hidingSpotManager.hidingSpots[i];
        }

        agent.destination = target.position;

    }

    private float IsTheHidingSpotBetweenMeAndTheSlime(Vector3 hidingSpot)
    {
        Vector3 slimeDirection = slime.position - transform.position;
        Vector3 hidingSpotDirection = hidingSpot - transform.position;

        float angle = Vector3.SignedAngle(slimeDirection, hidingSpotDirection, Vector3.up);
        Debug.Log("ANGLE: " + angle);
        return angle;
    }

    private void ConfirmHidingSpotSpace()
    {
        if (isEaten) return;

        if (target.gameObject.GetComponent<HidingSpot>().IsFull()) SelectTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Capacity Check"))
        {
            if(target.gameObject.GetComponent<HidingSpot>().IsFull()) SelectTarget();
        }

        if (other.CompareTag("Hiding Spot") && !isEaten)
        {
            agent.isStopped = true;
            isHidden = true;
        }

        if (other.CompareTag("Slime")) isEaten = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hiding Spot") && !isEaten)
        {
            Debug.Log("NOT HIDDEN");
            SelectTarget();
            isHidden = false;
        }
    }
}
