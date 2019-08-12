using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class TankController : MonoBehaviour
{
    [SerializeField] private float maxFiringRange = 10.0f;
    [SerializeField] private float turretRotationSpeed = 1.0f;
    [SerializeField] private float turretRotationOffset = -90.0f;
    [SerializeField] private Transform turret;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform muzzleFlashSpawnPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private float timeToStartFiringMin;
    [SerializeField] private float timeToStartFiringMax;
    [SerializeField] private float firingRepeatRateMin;
    [SerializeField] private float firingRepeatRateMax;

    private float _timeToStartFiring;
    private float _firingRepeatRate;

    private NavMeshAgent _agent;

    private void Start()
    {
        _timeToStartFiring = Random.Range(timeToStartFiringMin, timeToStartFiringMax);
        _firingRepeatRate = Random.Range(firingRepeatRateMin, firingRepeatRateMax);
        
        InvokeRepeating(nameof(FireProjectile), _timeToStartFiring, _firingRepeatRate);
        _agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(UpdateTargetLocation), 0f, 5.0f);
    }

    private void Update()
    {
        RotateTurret();
    }

    private void SetTarget(Vector3 targetPosition)
    {
        _agent.destination = targetPosition;
    }

    private void FireProjectile()
    {
        Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Instantiate(muzzleFlash, muzzleFlashSpawnPoint.position, muzzleFlashSpawnPoint.rotation);
    }

    private void UpdateTargetLocation()
    {
        SetTarget(GameManager.instance.player.transform.position);
    }

    private void RotateTurret()
    {
        var lookPosition = GameManager.instance.player.transform.position - transform.position;
        lookPosition.y = 0;
        var rotation = Quaternion.LookRotation(lookPosition);
        turret.rotation = Quaternion.Slerp(turret.rotation, rotation, Time.deltaTime * turretRotationSpeed);
        
    }
    
}
