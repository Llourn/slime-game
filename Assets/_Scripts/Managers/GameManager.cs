using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public HidingSpotManager hidingSpotManager;

    public GameObject player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Slime");
        hidingSpotManager = GetComponent<HidingSpotManager>();
    }
}
