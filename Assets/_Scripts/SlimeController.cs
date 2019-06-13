using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class SlimeController : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D _rb;
    private Collider2D _col;

    public LayerMask touchMask;
    public float moveSpeed = 10.0f;

    private void Start()
    {
        _col = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.position);
            touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    if(_col == Physics2D.OverlapPoint(touchPosition))
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                    break;
                case TouchPhase.Moved:
                    if (_col == Physics2D.OverlapPoint(touchPosition))
                        Debug.Log("Moving: " + touchPosition);
                        _rb.MovePosition(touchPosition);
                    break;
                case TouchPhase.Ended:
                    _rb.velocity = Vector2.zero;
                    break;
                default:
                    break;
            }

        }
    }
}
