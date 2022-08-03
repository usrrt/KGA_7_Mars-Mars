using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    

    private void Start()
    {
        StartCoroutine("MeteoCooltime");
        
    }

    private void Update()
    {
    }

    IEnumerator MeteoCooltime()
    {
        while(true)
        {
            Meteorities obj = null;
            int randTime = Random.Range(1, 10);
            Debug.Log(randTime);
            if(randTime == 2)
            {
                obj = MeteoPool.GetObject();
                obj.gameObject.transform.position = transform.position;
            }
            yield return new WaitForSeconds(5f);
            if(obj != null)
            { 
                MeteoPool.ReturnObject(obj);
            }
        }
    }
}
