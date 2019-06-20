using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHumans : MonoBehaviour
{
    public float absorbSpeed = 1.0f;
    private float moveTowardsStep;

    private void Update()
    {
        moveTowardsStep = absorbSpeed * Time.deltaTime;
        AbsorbTheChildren();
    }

    private void AbsorbTheChildren()
    {
        foreach(Transform child in transform)
        {
            child.position = Vector3.MoveTowards(child.position, transform.position, moveTowardsStep);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Human"))
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.transform.SetParent(this.transform);
        }
    }


}
