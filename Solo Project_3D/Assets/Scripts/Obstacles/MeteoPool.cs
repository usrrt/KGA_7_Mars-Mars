using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoPool : MonoBehaviour
{
    public static MeteoPool Instance; // ��ũ��Ʈ ��������ȭ
    public GameObject MeteorPrefab; // ������ ������

    private Queue<Meteorities> Q = new Queue<Meteorities>(); // ����ҿ���

    private void Awake()
    {
        Instance = this; // ��ü �ڱ��ڽ��� ����Ŵ
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
        // ������ ������Ʈ�� ������ 
        if (Instance.Q.Count > 0)
        {
            var obj = Instance.Q.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        // ������
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