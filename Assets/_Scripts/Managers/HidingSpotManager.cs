using System.Collections.Generic;
using UnityEngine;

public class HidingSpotManager : MonoBehaviour
{
    public List<Transform> hidingSpots;

    private void Awake()
    {
        hidingSpots = new List<Transform>();
    }

    public void RegisterSpot(Transform spot)
    {
        hidingSpots.Add(spot);
    }

    public void UnRegisterSpot(Transform spot)
    {
        hidingSpots.Remove(spot);
    }

}
