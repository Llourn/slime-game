using UnityEngine;
using UnityEngine.AI;

public class FindSafety : MonoBehaviour
{
    public Transform target;
    private Transform slime;
    private NavMeshAgent agent;
    private bool canWander = true;
    private bool slimeNear = false;
    private bool isHidden = false;
    private bool isEaten = false;

    public float wanderRadius;
    public float wanderTimer;

    private float timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        slime = GameManager.instance.player.transform;
    }

    private void Update()
    {
        if (!isEaten && agent.remainingDistance < 0.1f && !isHidden && !canWander) canWander = true;

        if (!canWander) return;
        WanderAround();
    }

    private void WanderAround()
    {
        timer += Time.deltaTime;
        if (timer >= wanderTimer && !isEaten)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    private Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public bool IsSafe()
    {
        return isHidden;
    }

    public void Ate()
    {
        isEaten = true;
    }

    public bool isAte()
    {
        return isEaten;
    }

    public void SelectTarget()
    {
        if (isEaten) return;
        canWander = false;
        slimeNear = true;
        target = null;
        float distance = Mathf.Infinity;
        for (int i = 0; i < GameManager.instance.hidingSpotManager.hidingSpots.Count; i++)
        {
            // if (GameManager.instance.hidingSpotManager.hidingSpots.Count <= 0 || IsTheHidingSpotBetweenMeAndTheSlime(GameManager.instance.hidingSpotManager.hidingSpots[i].position) < 90.0f) continue;

            float t = Vector3.Distance(this.transform.position, GameManager.instance.hidingSpotManager.hidingSpots[i].position);
            if (t < distance) target = GameManager.instance.hidingSpotManager.hidingSpots[i];
        }
        
        if (target == null)
        {
            Vector3 generalTarget = (transform.position - slime.position) * Vector3.Distance(transform.position, slime.position);
            //agent.ResetPath();
            agent.destination = generalTarget;
            return;
        }
        //agent.ResetPath();
        agent.destination = target.position;
    }

    private float IsTheHidingSpotBetweenMeAndTheSlime(Vector3 hidingSpot)
    {
        Vector3 thisPosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 objectAPosition = new Vector3(hidingSpot.x, 0.0f, hidingSpot.z);
        Vector3 objectBPosition = new Vector3(slime.position.x, 0.0f, slime.position.z);

        Vector3 directionA = objectAPosition - thisPosition;
        Vector3 directionB = objectBPosition - thisPosition;

        float angle = Vector3.Angle(directionA, directionB);
        return angle;
    }

    private void ConfirmHidingSpotSpace()
    {
        if (isEaten) return;

        if (target.gameObject.GetComponent<HidingSpot>().IsFull()) SelectTarget();
    }

    public Transform GetTarget()
    {
        return target;
    }

    public void StartHiding()
    {
        if (isEaten) return;
        agent.isStopped = true;
        isHidden = true;
    }

    public void StopHiding()
    {
        if (isEaten) return;
        agent.isStopped = false;
        isHidden = false;
        SelectTarget();
    }

}
