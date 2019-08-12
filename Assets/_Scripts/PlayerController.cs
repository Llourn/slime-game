using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float rotateSpeed = 3.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private SlimeAnimationSpeedMultiplier sasm;
    [SerializeField] private Animator modelAnimator;
    [SerializeField] private int scoreRequiredForLevel2;
    [SerializeField] private int scoreRequiredForLevel3;
    [SerializeField] private Vector3 level2Scale = Vector3.zero;
    [SerializeField] private float level2Speed = 6.0f;
    [SerializeField] private Vector3 level3Scale = Vector3.zero;
    [SerializeField] private float level3Speed = 8.0f;
    [SerializeField] private bool pauseMovement = false;
    

    private Animator _animator;
    private ParticleSystem _slimeTrail;
    private ParticleSystem.MainModule _stMain;

    private const float Level1SlimeTrailSize = 2.8f;
    private const float Level2SlimeTrailSize = 6.0f;
    private const float Level3SlimeTrailSize = 11.0f;

    private int _playerLevel = 1;
    private int _playerScore;

    private Vector3 _moveDirection = Vector3.zero;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _slimeTrail = GetComponentInChildren<ParticleSystem>();
        _stMain = _slimeTrail.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_playerLevel == 1) Level2Granted();
            else if (_playerLevel == 2) Level3Granted();
        }

        if(_characterController.isGrounded && !pauseMovement)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _moveDirection *= (speed * sasm.multiplier);
        }
        _moveDirection.y -= gravity * Time.deltaTime;

        Vector3 rotTarget = new Vector3(_moveDirection.x, 0.0f, _moveDirection.z);
        modelAnimator.SetFloat("moveSpeed", rotTarget.magnitude);
        _characterController.Move(_moveDirection * Time.deltaTime);

        float step = rotateSpeed * Time.deltaTime;
        if (rotTarget == Vector3.zero) return;
        transform.rotation = Quaternion.LookRotation(rotTarget);

    }

    public int GetPlayerLevel()
    {
        return _playerLevel;
    }

    public void IncreasePlayerLevel()
    {
        _playerLevel++;
    }

    public void ResetPlayerLevel()
    {
        _playerLevel = 1;
        transform.localScale = Vector3.one;
        speed = 4.0f;
        _stMain.startSize = Level1SlimeTrailSize;
    }

    public void IncreasePlayerScore(int amount)
    {
        _playerScore += amount;
        if (_playerScore > scoreRequiredForLevel2 && _playerLevel == 1)
        {
            Level2Granted();
        }
        if (_playerScore > scoreRequiredForLevel3 && _playerLevel == 2)
        {
            Level3Granted();
        }
    }

    private void Level2Granted()
    {
        Debug.Log("LEVEL 2 GRANTED");
        _playerLevel++;
        pauseMovement = true;
        _animator.SetTrigger("GrowToLevel2");
        speed = level2Speed;
        _stMain.startSize = Level2SlimeTrailSize;
    }

    private void Level3Granted()
    {
        _playerLevel++;
        Debug.Log("LEVEL 3 GRANTED");
        pauseMovement = true;
        _animator.SetTrigger("GrowToLevel3");
        speed = level3Speed;
        _stMain.startSize = Level3SlimeTrailSize;
    }

    public void EnablePlayerMovement()
    {
        pauseMovement = false;
        _moveDirection = Vector3.zero;
    }
    
}
