using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    [SerializeField] private int maxHidingCount = 5;
    private int hidingCount = 0;

    private void Start()
    {
        GameManager.instance.hidingSpotManager.RegisterSpot(this.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            ++hidingCount;
            if (hidingCount >= maxHidingCount) UnRegisterHidingSpot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            --hidingCount;
            if (hidingCount < maxHidingCount) RegisterHidingSpot();
        }
    }

    private void RegisterHidingSpot()
    {
        GameManager.instance.hidingSpotManager.RegisterSpot(this.transform);
    }

    private void UnRegisterHidingSpot()
    {
        GameManager.instance.hidingSpotManager.UnRegisterSpot(this.transform);
    }

}
