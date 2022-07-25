using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private float JumpForce = 800f;
    [SerializeField]
    private float MoveSpeed = 15;

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
    public float JetPackUp;
    private void Move()
    {
        float movementAmount = MoveSpeed * Time.deltaTime;
        //Debug.Log(movementAmount);
        if (_canMove)
        {
            float upPush = _input.MoveDirection * Time.deltaTime * 6;
            if (upPush < 0)
            {
                upPush *= -1;
            }
            //Debug.Log(upPush);

            if (_input.RightJetForce && _input.LeftJetForce)
            {
                _rigidbody.AddForce(new Vector2(0f, JetPackUp), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody.AddForce(new Vector2(_input.MoveDirection * movementAmount, upPush), ForceMode2D.Impulse);
            }
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
