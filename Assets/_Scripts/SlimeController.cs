using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Ball;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody))]
public class SlimeController : MonoBehaviour
{
    private Vector3 _touchPosition;
    private bool _moveEnabled;

    // Reference cache
    Rigidbody _rbody;
    public Ball ball;

    public LayerMask touchMask;
    public float moveSpeed = 1.0f;

    private void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        ball = GetComponent<Ball>();
    }

    private void Update()
    {

        Vector3 velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0.0f, CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;
        ball.Move(velocity, false);

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    switch(touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            if(HitSlime(touch))
        //            {
        //                _moveEnabled = true;
        //                _rbody.useGravity = false;
        //            }
        //            // Check if the slime was hit with the ray.
        //            // If the slime was hit, enable move mode where swiping on screen moves the slime.
        //            break;
        //        case TouchPhase.Moved:
        //            // if move mode enabled, move the slime.
        //            if(_moveEnabled)
        //            {
        //                Vector3 pos = _rbody.position;
        //                Vector2 dPos = touch.deltaPosition;
        //                _rbody.MovePosition(new Vector3(pos.x + dPos.x, pos.y, pos.z + dPos.y) * moveSpeed);
        //            }
        //            Debug.Log("Delta Position: " + touch.deltaPosition);
        //            break;
        //        case TouchPhase.Ended:
        //            // if move mode enabled, release the slime. 
        //            _moveEnabled = false;
        //            _rbody.useGravity = true;
        //            break;
        //        default:
        //            break;
        //    }

        //}

    }

    private void LateUpdate()
    {
        

        
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
