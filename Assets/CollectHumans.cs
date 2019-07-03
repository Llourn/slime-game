using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHumans : MonoBehaviour
{
    public float absorbSpeed = 1.0f;
    public float disintegrateSpeed = 1.0f;
    public Vector3 smallestSize;

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
        foreach(Transform child in transform)
        {
            if (Vector3.Distance(transform.position, child.position) > 0.3)
                child.position = Vector3.MoveTowards(child.position, transform.position, moveTowardsStep);
            else
                child.localScale = Vector3.Lerp(child.localScale, smallestSize, disintegrateStep);
            if (child.localScale.x <= 0.04f) Destroy(child.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Human") || other.gameObject.layer == 13)
        {

            if (other.gameObject.layer == 13) Debug.Log("This is debris.");
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.SetParent(this.transform);
            if(other.CompareTag("Human")) other.transform.rotation = Random.rotation;
        }
    }


}
