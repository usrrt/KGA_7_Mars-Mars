using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _controller;
    private Rigidbody _rigidbody;

    // 이동시 더하는 힘
    [SerializeField]
    private float JumpForce = 20f;
    [SerializeField]
    private float MoveSpeed = 12;
    [SerializeField]
    private float Booster = 0.1f;

    public float MaxVelocity;

    public bool _isOnGround = true;
    public int _jumpCount = 0;

    

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // 저장된 위치를 시작위치로 한다.
        transform.position = GameManager.Instance.LastCheckPoint + new Vector2(0f, 1f);
    }

    private void Update()
    {
        GameManager.Instance.fallingSpeed = _rigidbody.velocity.y * -1;

        if( _isOnGround == true && _jumpCount == 0)
        {
            Jump();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        float movementAmount = MoveSpeed * Time.deltaTime;

        if(_isOnGround == false)
        {
            float upThrust = _controller.MoveDirection * movementAmount / 2;
            if(upThrust < 0)
            {
                upThrust *= -1;
            }
            
            if(_controller.BoostUp)
            {
                _rigidbody.AddForce(_rigidbody.transform.up * Booster, ForceMode.Impulse);
            }
            
            _rigidbody.AddForce(new Vector2(_controller.MoveDirection * movementAmount, upThrust), ForceMode.Impulse);
             LimitSpeed();
            
        }
        
    }

    private void LimitSpeed()
    {
        if (_rigidbody.velocity.x > MaxVelocity)
        {
            _rigidbody.velocity = new Vector2(MaxVelocity, _rigidbody.velocity.y);
        }
        if (_rigidbody.velocity.x < (MaxVelocity * -1))
        {
            _rigidbody.velocity = new Vector2((MaxVelocity * -1), _rigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if(_controller.CanJump)
        {
            _rigidbody.AddForce(_rigidbody.transform.up * JumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _jumpCount++;
        }
    }
}
