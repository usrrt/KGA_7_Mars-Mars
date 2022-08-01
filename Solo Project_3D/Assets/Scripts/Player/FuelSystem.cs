using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    private PlayerMovement _movement;

    public float CurrentFuel = 100f;
    public float FuelEfficiency = 0.3f;
    public bool CanMove = false;

    public Slider FuelSilder;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        FuelSilder.maxValue = CurrentFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && _movement._isOnGround == false)
        {
            if(CurrentFuel > 0)
            {
                CanMove = true;
            }
            else
            {
                CanMove = false;
                return;
            }
            CurrentFuel -= FuelEfficiency;
        }
        FuelSilder.value = CurrentFuel;
    }
}
