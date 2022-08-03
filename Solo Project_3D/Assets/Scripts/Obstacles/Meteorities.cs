using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorities : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float FallSpeed = 45f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-20, FallSpeed * -1, 0f) * Time.deltaTime);
    }
}
