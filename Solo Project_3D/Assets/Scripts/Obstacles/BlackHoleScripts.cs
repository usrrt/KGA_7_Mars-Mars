using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float rotSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0, Time.deltaTime * rotSpeed * -1));
    }
}
