using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public HidingSpotManager hidingSpotManager;

    public GameObject player = null;

    [Header("Manually attach reference.")]
    public Transform humanContainer = null;
    [SerializeField] GameObject playerPrefab = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (player == null)
        {
            player = Instantiate(playerPrefab, transform.position, Quaternion.identity, transform);
        }
        hidingSpotManager = GetComponent<HidingSpotManager>();
    }
}
