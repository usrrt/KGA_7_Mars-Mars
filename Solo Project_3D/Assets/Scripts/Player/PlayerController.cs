using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string MoveAxisName = "Horizontal";

    public float MoveDirection { get; private set; }
    public bool CanJump { get; private set; }
    public bool BoostUp { get; private set; }


    private FuelSystem FuelSystem;
    
    public ParticleSystem RightJet;
    public ParticleSystem LeftJet;

    private void Awake()
    {
        FuelSystem = GetComponent<FuelSystem>();
    }

    private void Update()
    {
        MoveDirection = Input.GetAxis(MoveAxisName);
        CanJump = Input.GetKeyDown(KeyCode.Space);

        BoostUp = Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow);

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RightJet.Play();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || FuelSystem.CanMove == false)
        {
            RightJet.Stop();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LeftJet.Play();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || FuelSystem.CanMove == false)
        {
            LeftJet.Stop();
        }

    }
}
