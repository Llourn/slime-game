using UnityEngine;
using UnityEngine.AI;

public class Collect : MonoBehaviour
{
    public float absorbSpeed = 1.0f;
    public float disintegrateSpeed = 1.0f;
    public Vector3 smallestSize;
    public Transform collectionContainer;

    private float moveTowardsStep;
    private float disintegrateStep;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        moveTowardsStep = absorbSpeed * Time.deltaTime;
        disintegrateStep = disintegrateSpeed * Time.deltaTime;
        AbsorbTheChildren();
    }

    private void AbsorbTheChildren()
    {
        foreach (Transform child in collectionContainer)
        {
            if (Vector3.Distance(collectionContainer.position, child.position) > 0.3)
                child.position = Vector3.MoveTowards(child.position, collectionContainer.position, moveTowardsStep);
            else
                child.localScale = Vector3.Lerp(child.localScale, smallestSize, disintegrateStep);
            if (child.localScale.x <= 0.04f) Destroy(child.gameObject);
        }
    }

    public void CollectHumans(GameObject obj)
    {
        Debug.Log("Collected Human: " + obj.name);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<NavMeshAgent>().enabled = false;
        obj.transform.SetParent(collectionContainer);
        obj.transform.rotation = Random.rotation;
    }

    public void CollectDebris(GameObject obj)
    {
        Debug.Log("Collected Debris: " + obj.name);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Collider>().enabled = false;
        obj.transform.SetParent(collectionContainer);
    }

    private void CollectEtc(GameObject obj)
    {
        Debug.Log("Collected Etc: " + obj.name);
        obj.transform.SetParent(collectionContainer);
        obj.transform.rotation = Random.rotation;
    }

    public void Level1Collect(GameObject obj)
    {
        if (obj.layer == 11)
        {
            obj.GetComponent<FindSafety>().Ate();
            CollectHumans(obj);
            playerController.IncreasePlayerScore(10);
        }
        else if (obj.layer == 13)
        {
            CollectDebris(obj);
            playerController.IncreasePlayerScore(10);
        }
        else
        {
            CollectEtc(obj);
            playerController.IncreasePlayerScore(10);
        }

    }

    public void Level2Collect(GameObject obj)
    {
        if (playerController.GetPlayerLevel() < 2) return;

        CollectEtc(obj);
        playerController.IncreasePlayerScore(25);
    }

    public void Level3Collect(GameObject obj)
    {
        if (playerController.GetPlayerLevel() < 3) return;
        CollectEtc(obj);
        playerController.IncreasePlayerScore(50);
    }

}