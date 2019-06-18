using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformExterior : MonoBehaviour
{
    public float moveForce = 10f;
    private void OnTriggerStay(Collider other)
    {
        MeshDeformer deformer = other.gameObject.GetComponent<MeshDeformer>();
        if (deformer)
        {
            Debug.Log("Is this working??");
            deformer.AddDeformingForce(other.ClosestPoint(transform.position), moveForce);
        }
    }
}
