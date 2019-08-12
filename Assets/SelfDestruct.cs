using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;

    private void Start()
    {
        Debug.Log("Is this getting called?");
        Destroy(gameObject, timeToDestroy);        
    }
}
