using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAngle : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    private void Update()
    {
        Vector3 thisPosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 objectAPosition = new Vector3(objectA.position.x, 0.0f, objectA.position.z);
        Vector3 objectBPosition = new Vector3(objectB.position.x, 0.0f, objectB.position.z);


        Vector3 directionA = objectAPosition - thisPosition;
        Vector3 directionB = objectBPosition - thisPosition;

        float angle = Vector3.Angle(directionA, directionB);

        Debug.Log("ANGLE: " + angle);
    }
}
