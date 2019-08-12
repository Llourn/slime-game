using System;
using UnityEngine;

public class TankProjectile : MonoBehaviour
{
    [SerializeField] private float launchForce = 1.0f;
    [SerializeField] private GameObject explosion;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        _rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 explosionAngle = other.contacts[0].normal;
        Instantiate(explosion, transform.position, Quaternion.FromToRotation(Vector3.up, explosionAngle));
        Destroy(this.gameObject);
    }
}
