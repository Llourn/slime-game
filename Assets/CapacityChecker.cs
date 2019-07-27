using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityChecker : MonoBehaviour
{
    private FindSafety findSafety;

    private void Start()
    {
        findSafety = GetComponentInParent<FindSafety>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Capacity Check"))
        {
            if (findSafety == null || findSafety.isAte() || findSafety.GetTarget() == null) return;
            if (findSafety.GetTarget().gameObject.GetComponent<HidingSpot>().IsFull()) findSafety.SelectTarget();
        }
    }
}
