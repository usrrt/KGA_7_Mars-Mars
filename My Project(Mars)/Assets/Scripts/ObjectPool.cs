using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject _poolingObjectPrefab;

    private Queue<Platform> _poolingObjectQueue = new Queue<Platform>();

    private void Awake()
    {
        Instance = this;

        Initialize(4); // 생성숫자 기입
    }

    private Platform CreateNewObject()
    {
        // Instantiate함수로 새 오브젝트 만듬
        var newObject = Instantiate(_poolingObjectPrefab, transform).GetComponent<Platform>();
        // 비활성화후 objectPool의 자식 게임 오브젝트로 만든다음 반환
        newObject.gameObject.SetActive(false);
        return newObject;
    }

    // 매개변수로 받은 수만큼 미리 풀링할 오브젝트 생성하는 역할
    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    // ObjectPool에서 오브ㅡ젝트를 빌려갈때 사용할 GetObject함수
    public static Platform GetObject()
    {
        // 오브젝트를 빌려가는 순간상황은 빌려줄 오브젝트가 있을때와 없을때로 나뉜다
        if (Instance._poolingObjectQueue.Count > 0)
        {
            // 빌려줄 오브젝트가 있으므로 큐에서 꺼낸 오브젝트를 활성화해서 빌려준다
            var obj = Instance._poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            // 새 오브젝트를 만들어 빌려줌
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    // 빌려준 오브젝트를 돌려받는 함수, 매개변수로 돌려받을 게임오브젝트를 받는다
    public static void ReturnObject(Platform platform)
    {
        // 돌려받을 게임오브젝트를 받아와 비활성화
        platform.gameObject.SetActive(false);
        // ObjectPool아래에 옮긴 뒤 poolingObjectQueue에 넣는 작업을 처리
        platform.transform.SetParent(Instance.transform);
        Instance._poolingObjectQueue.Enqueue(platform);
    }
}
