using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformExterior : MonoBehaviour
{
    public float moveForce = 10f;

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
