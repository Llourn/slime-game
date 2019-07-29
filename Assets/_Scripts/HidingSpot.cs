using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    [SerializeField] private int maxHidingCount = 5;
    [SerializeField] private Material registered = null;
    [SerializeField] private Material unregistered = null;
    [SerializeField] private Renderer buildingRenderer = null;

    private int hidingCount = 0;

    private void Start()
    {
        GameManager.instance.hidingSpotManager.RegisterSpot(this.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            ++hidingCount;
            if (hidingCount >= maxHidingCount) UnRegisterHidingSpot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            --hidingCount;
            if (hidingCount < maxHidingCount) RegisterHidingSpot();
        }
    }

    private void RegisterHidingSpot()
    {
        GameManager.instance.hidingSpotManager.RegisterSpot(this.transform);
        buildingRenderer.materials[1] = registered;
        Debug.Log("Building registered!");
    }

    private void UnRegisterHidingSpot()
    {
        GameManager.instance.hidingSpotManager.UnRegisterSpot(this.transform);
        buildingRenderer.materials[1] = unregistered;
    }
    public bool IsFull()
    {
        return hidingCount >= maxHidingCount;
    }

}
