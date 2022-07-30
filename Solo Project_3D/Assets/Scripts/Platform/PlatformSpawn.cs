using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    // 생성할 플랫폼 프리펩
    public GameObject PlatformPrefab;
    public int MaxPlatformCnt = 100;

    // 발판 생성가능 거리
    private float platformMakePos;
    public float xPlusPos;

    // 배치 위치값
    public float xMin = 15f;
    public float xMax = 30f;
    public float yMin = 0f;
    public float yMax = 10f;

    private GameObject[] _platforms; // 생성한 플랫폼 배열에 담음
    private int _nextSpawnPlatformIndex = 0; // 사용할 발판 순번

    public Vector2 prevCheckPoint;
    public Vector2 currentCheckPoint;

    // 발판 숨길 위치
    private readonly Vector2 _poolPosition;

    private void Start()
    {
        _poolPosition.Set(0f, -50f);
        _platforms = new GameObject[MaxPlatformCnt];
        for(int i = 0; i < MaxPlatformCnt; i++)
        {
            _poolPosition.Set(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            _platforms[i] = Instantiate(PlatformPrefab, _poolPosition, Quaternion.identity); // 생성한 플랫폼 배열에 넣어둠
            _platforms[i].SetActive(true);
        }
    }

    private void Update()
    {
        // 순서돌아가며 발판배치
        // 체크포인트 위치 기준 +xPos 만큼을 플랫폼 생성위치로 한다
        platformMakePos = GameManager.Instance.LastCheckPoint.x + xPlusPos;

        if(prevCheckPoint != currentCheckPoint)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            GameObject currentPlatform = _platforms[_nextSpawnPlatformIndex];
            currentPlatform.transform.position = spawnPosition;

            currentPlatform.SetActive(false);
            currentPlatform.SetActive(true);

            _nextSpawnPlatformIndex = (_nextSpawnPlatformIndex + 1) % MaxPlatformCnt;
        }
    }
}
