using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Devour : MonoBehaviour
{
    private Collect collect;

    private void Start()
    {
        collect = GetComponentInParent<Collect>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("L1 Edible"))
        {
            collect.Level1Collect(other.gameObject);
        }

        if(other.CompareTag("L2 Edible"))
        {
            collect.Level2Collect(other.gameObject);
        }

        if (other.CompareTag("L3 Edible"))
        {
            collect.Level3Collect(other.gameObject);
        }
    }
}
