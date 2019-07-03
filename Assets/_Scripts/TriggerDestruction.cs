using UnityEngine;

public class TriggerDestruction : MonoBehaviour
{
    public GameObject unbroken;
    public GameObject broken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
            unbroken.SetActive(false);
            broken.SetActive(true);
        }
    }
}
