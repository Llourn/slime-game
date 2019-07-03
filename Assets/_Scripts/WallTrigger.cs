using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public GameObject unbroken;
    public GameObject broken;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Slime"))
        {
            unbroken.SetActive(false);
            broken.SetActive(true);
        }
    }
}
