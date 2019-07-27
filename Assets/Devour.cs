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
        if (other.CompareTag("Human"))
        {
            other.gameObject.GetComponent<FindSafety>().Ate();
            collect.CollectHumans(other.gameObject);
        }
        else if(other.gameObject.layer == 13)
        {
            collect.CollectDebris(other.gameObject);
        }

    }
}
