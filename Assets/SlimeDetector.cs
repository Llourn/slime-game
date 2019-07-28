using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDetector : MonoBehaviour
{
    [SerializeField] private FindSafety findSafety = null;
    [SerializeField] private LayerMask slimeMask = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (findSafety.IsSafe()) return;
        if (other.CompareTag("Slime")) IsSlimeInLineOfSight();
    }

    private bool IsSlimeInLineOfSight()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, GameManager.instance.player.transform.position - transform.position, out hit, Mathf.Infinity, slimeMask))
        {
            Debug.DrawRay(transform.position, (GameManager.instance.player.transform.position - transform.position) * hit.distance, Color.red);
            if (hit.transform.CompareTag("Slime") || hit.transform.CompareTag("Eater"))
            {
                findSafety.SelectTarget();
                return true;
            }
            return false;
        }
        return false;
    }
}
