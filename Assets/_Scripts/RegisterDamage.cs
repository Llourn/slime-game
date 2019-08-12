using UnityEngine;

public class RegisterDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("DIRECT HIT!");
    }
}
