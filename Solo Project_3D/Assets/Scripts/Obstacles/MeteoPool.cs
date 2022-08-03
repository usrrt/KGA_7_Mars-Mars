using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoPool : MonoBehaviour
{
    public static MeteoPool Instance; // 스크립트 전역변수화
    public GameObject MeteorPrefab; // 가져올 프리펩

    private Queue<Meteorities> Q = new Queue<Meteorities>(); // 저장소역할

    private void Awake()
    {
        Instance = this; // 객체 자기자신을 가리킴
        Initilize(5);
    }

    private Meteorities CreateNewObject() 
    {
        var newObj = Instantiate(MeteorPrefab, transform).GetComponent<Meteorities>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    private void Initilize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Q.Enqueue(CreateNewObject());
        }
    }

    public static Meteorities GetObject()
    {
        // 빌려줄 오브젝트가 있을때 
        if (Instance.Q.Count > 0)
        {
            var obj = Instance.Q.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        // 없을때
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Meteorities obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.Q.Enqueue(obj);
    }
}