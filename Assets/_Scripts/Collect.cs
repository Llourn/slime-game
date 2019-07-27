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
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<NavMeshAgent>().enabled = false;
        obj.transform.SetParent(collectionContainer);
        obj.transform.rotation = Random.rotation;
    }

    public void CollectDebris(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(collectionContainer);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.SetParent(collectionContainer);
            other.transform.rotation = Random.rotation;
        }

        if (other.gameObject.layer == 13)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.SetParent(collectionContainer);
        }
    }
    */

}