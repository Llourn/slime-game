using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTanks : MonoBehaviour
{
    public GameObject tank1;
    public GameObject tank2;
    public GameObject tank3;
    public GameObject tank4;
    public GameObject tank5;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateAllTanks();
        }
    }

    private void ActivateAllTanks()
    {
        tank1.SetActive(true);
        tank2.SetActive(true);
        tank3.SetActive(true);
        tank4.SetActive(true);
        tank5.SetActive(true);
    }
    
}
