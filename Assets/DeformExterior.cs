using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformExterior : MonoBehaviour
{
    public float moveForce = 10f;
    public float forceThreshold = 0.1f;

    private MeshDeformer deformer;

    private void Start()
    {
        deformer = GetComponent<MeshDeformer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (deformer)
        {
            Debug.Log("WORK DAMMIT");
            deformer.AddDeformingForce(other.ClosestPoint(transform.position), moveForce);
        }
    }


}
