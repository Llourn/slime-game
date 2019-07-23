using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public HidingSpotManager hidingSpotManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        hidingSpotManager = GetComponent<HidingSpotManager>();
    }
}
