using UnityEngine;

public class TriggerDestruction : MonoBehaviour
{
    public GameObject unbroken;
    public GameObject broken;
    [SerializeField] Transform hidingSpot = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
            if(GameManager.instance.GetPlayerLevel() >= 3)
            {
                GameManager.instance.hidingSpotManager.UnRegisterSpot(hidingSpot);
                unbroken.SetActive(false);
                broken.SetActive(true);
            }
        }
    }
}
