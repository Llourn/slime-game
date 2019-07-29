﻿using UnityEngine;

public class HidingSpotDetector : MonoBehaviour
{
    private FindSafety findSafety;

    private void Start()
    {
        findSafety = GetComponentInParent<FindSafety>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hiding Spot"))
        {
            findSafety.StartHiding();
        }

        if(other.CompareTag("RUN"))
        {
            findSafety.StopHiding();
        }
    }

}
