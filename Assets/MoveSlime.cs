using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveSlime : MonoBehaviour
{
    private Rigidbody _rbody;

    public float moveSpeed;

    public bool keyboardInput = false;

    private void Start()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 velocity;
        if (!keyboardInput)
            velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0.0f, CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;
        else
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * moveSpeed;

        _rbody.AddForce(velocity, ForceMode.Force);
    }
}
