using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public HidingSpotManager hidingSpotManager;

    public GameObject player = null;

    [Header("Manually attach reference.")]
    public Transform humanContainer = null;
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private CameraFollow cameraFollow;


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
            cameraFollow.target = player.transform;

        }
        hidingSpotManager = GetComponent<HidingSpotManager>();
    }

    public int GetPlayerLevel()
    {
        return player.GetComponent<PlayerController>().GetPlayerLevel();
    }
}
