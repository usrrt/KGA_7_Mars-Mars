using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private PlayerState _state;

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
        _state = GetComponent<PlayerState>();
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
        //Debug.Log($"y속도: {Vector2.right * Time.deltaTime * JumpForce}");
        if (_input.CanJump)
        {

            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Force);
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
            float upThrust = _input.MoveDirection * Time.deltaTime * 6;
            if (upThrust < 0)
            {
                upThrust *= -1;
            }
            //Debug.Log(upPush);

            if (_input.RightJetForce && _input.LeftJetForce)
            {
                _rigidbody.AddForce(new Vector2(0f, JetPackUp), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody.AddForce(new Vector2(_input.MoveDirection * movementAmount, upThrust), ForceMode2D.Impulse);
                LimitSpeed();
                //Debug.Log(_rigidbody.velocity.x);
            }

        }
    }

    public float maxVelocityX;
    private void LimitSpeed()
    {
        if (_rigidbody.velocity.x > maxVelocityX)
        {
            _rigidbody.velocity = new Vector2(maxVelocityX, _rigidbody.velocity.y);
        }
        if (_rigidbody.velocity.x < (maxVelocityX * -1))
        {
            _rigidbody.velocity = new Vector2((maxVelocityX * -1), _rigidbody.velocity.y);
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

        Debug.Log($"{other.gameObject.tag}");

        if (other.gameObject.tag == "Ground")
        {
            _state.Die();
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // 공중에서만 좌우로 움직이게하기
        _canMove = true;
    }
}
