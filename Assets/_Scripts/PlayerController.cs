using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public Animator animator;

    public float speed = 6.0f;
    public float rotateSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [SerializeField] private Vector3 level2Scale = Vector3.zero;
    [SerializeField] private float level2Speed = 6.0f;
    [SerializeField] private Vector3 level3Scale = Vector3.zero;
    [SerializeField] private float level3Speed = 8.0f;

    private ParticleSystem slimeTrail;
    ParticleSystem.MainModule stMain;

    private float level1SlimeTrailSize = 2.8f;
    private float level2SlimeTrailSize = 6.0f;
    private float level3SlimeTrailSize = 11.0f;

    private int playerLevel = 1;
    private int playerScore = 0;

    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        slimeTrail = GetComponentInChildren<ParticleSystem>();
        stMain = slimeTrail.main;
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

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public void IncreasePlayerLevel()
    {
        playerLevel++;
    }

    public void ResetPlayerLevel()
    {
        playerLevel = 1;
        transform.localScale = Vector3.one;
        speed = 4.0f;
        stMain.startSize = level1SlimeTrailSize;
    }

    public void IncreasePlayerScore(int amount)
    {
        playerScore += amount;
        if (playerScore > 100 && playerLevel == 1)
        {
            playerLevel = 2;
            SlimeLevelUp();
            stMain.startSize = level2SlimeTrailSize;
        }
        if (playerScore > 500 && playerLevel == 2)
        {
            playerLevel = 3;
            SlimeLevelUp();
            stMain.startSize = level3SlimeTrailSize;
        }
    }

    private void SlimeLevelUp()
    {
        if(playerLevel == 2)
        {
            transform.localScale = level2Scale;
            speed = level2Speed;
        }
        else if(playerLevel == 3)
        {
            transform.localScale = level3Scale;
            speed = level3Speed;
        }
    }
}
