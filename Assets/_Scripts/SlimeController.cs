using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Ball;

[RequireComponent(typeof(Rigidbody))]
public class SlimeController : MonoBehaviour
{
    private Vector3 _touchPosition;
    private bool _moveEnabled;

    // Reference cache
    public Ball ball;

    public LayerMask touchMask;
    public float moveSpeed = 1.0f;

    private void Start()
    {
        ball = GetComponent<Ball>();
    }

    private void Update()
    {
        Vector3 velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0.0f, CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;
        ball.Move(velocity, false);
    }


    private bool HitSlime(Touch touch)
    {
        Vector3 touchPositionNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
        Vector3 touchPositionFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);

        Vector3 rayOrigin = Camera.main.ScreenToWorldPoint(touchPositionNear);
        Vector3 rayEndPoint = Camera.main.ScreenToWorldPoint(touchPositionFar);

        RaycastHit hit;
        Vector3 direction = rayEndPoint - rayOrigin;
        return Physics.Raycast(rayOrigin, direction, out hit, Mathf.Infinity, touchMask);
    }

}
