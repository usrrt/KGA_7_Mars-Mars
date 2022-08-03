using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string MoveAxisName = "Horizontal";

    public float MoveDirection { get; private set; }
    public bool CanJump { get; private set; }
    public bool BoostUp { get; private set; }

    private Animator _animator;
    private FuelSystem FuelSystem;
    
    public ParticleSystem RightJet;
    public ParticleSystem LeftJet;

    private void Awake()
    {
        FuelSystem = GetComponent<FuelSystem>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        MoveDirection = Input.GetAxis(MoveAxisName);
        CanJump = Input.GetKeyDown(KeyCode.Space);
        if (CanJump)
        {
            _animator.SetBool(PlayerAnimID.End, false);
            _animator.SetTrigger(PlayerAnimID.Start);
        }

        BoostUp = Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow);

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RightJet.Play();

            _animator.SetBool(PlayerAnimID.Flip, true);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || FuelSystem.CanMove == false)
        {
            RightJet.Stop();
            _animator.SetBool(PlayerAnimID.Flip, false);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LeftJet.Play();
            _animator.SetBool(PlayerAnimID.Flip, true);


        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || FuelSystem.CanMove == false)
        {
            LeftJet.Stop();
            _animator.SetBool(PlayerAnimID.Flip, false);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("SafeZone"))
        {
            _animator.SetBool(PlayerAnimID.End, true);
        }
    }
}
