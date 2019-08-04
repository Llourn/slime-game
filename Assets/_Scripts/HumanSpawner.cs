using UnityEngine;
using UnityEngine.AI;

public class HumanSpawner : MonoBehaviour
{
    [SerializeField] GameObject humanPrefab = null;

    public float maxDistance = 20.0f;
    public int humanCount = 10;

    private void Start()
    {
        SpawnHumans();
    }
    private void SpawnHumans()
    {
        for(int i = 0; i < humanCount; i++)
        {
            Vector3 point = GetRandomPoint();
            while(Mathf.Abs(point.x) > 1000)
            {
                point = GetRandomPoint();
            }
            Instantiate(humanPrefab, point, Quaternion.identity, GameManager.instance.humanContainer);
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + transform.position;
        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        return hit.position;
    }


}
