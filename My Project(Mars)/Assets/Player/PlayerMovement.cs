using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

    public float JumpForce;
    public float MoveSpeed;

    private int _jumpCount = 0;
    private bool _isOnGround = true;
    private bool _canMove = false;

    private static readonly float MIN_NOMAL_Y = Mathf.Sin(45f * Mathf.Deg2Rad);

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isOnGround != false && _jumpCount == 0)
        {
            Jump();
        }

        Move();
    }
    private void Jump()
    {
        if (_input.CanJump)
        {
            //_rigidbody.transform.Translate(new Vector3(10f * Time.deltaTime, 0f, 0));
            _rigidbody.AddForce(new Vector2(JumpForce % 10, JumpForce));
            _isOnGround = false;
            _jumpCount++;
        }
    }

    private void Move()
    {
        float movementAmount = MoveSpeed * Time.deltaTime;
        //Debug.Log(movementAmount);
        if (_canMove)
        {
            float upPush = _input.MoveDirection * movementAmount;
            if (upPush < 0)
            {
                upPush *= -1;
            }


            _rigidbody.transform.Translate(new Vector3(_input.MoveDirection * movementAmount, upPush, 0f));
            Debug.Log(upPush);


        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _canMove = false;

        ContactPoint2D point = other.GetContact(0);
        if (point.normal.y >= MIN_NOMAL_Y)
        {
            _isOnGround = true;
            _jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // 공중에서만 좌우로 움직이게하기
        _canMove = true;
    }
}
