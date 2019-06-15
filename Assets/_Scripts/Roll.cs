using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Roll : MonoBehaviour
{

    public float moveSpeed = 1.0f;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0.0f, CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;

        Vector3 targetRotation = (transform.rotation.eulerAngles + velocity);

        transform.Rotate(targetRotation);
    }
}
