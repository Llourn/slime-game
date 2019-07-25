using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public Animator animator;

    public float speed = 6.0f;
    public float rotateSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;

        Vector3 rotTarget = new Vector3(moveDirection.x, 0.0f, moveDirection.z);
        animator.SetFloat("moveSpeed", rotTarget.magnitude);
        characterController.Move(moveDirection * Time.deltaTime);

        float step = rotateSpeed * Time.deltaTime;
        if (rotTarget == Vector3.zero) return;
        transform.rotation = Quaternion.LookRotation(rotTarget);
    }
}
