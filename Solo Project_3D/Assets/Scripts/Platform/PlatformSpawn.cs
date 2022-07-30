using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    // ������ �÷��� ������
    public GameObject PlatformPrefab;
    public int MaxPlatformCnt = 100;

    // ���� �������� �Ÿ�
    private float platformMakePos;
    public float xPlusPos;

    // ��ġ ��ġ��
    public float xMin = 15f;
    public float xMax = 30f;
    public float yMin = 0f;
    public float yMax = 10f;

    private GameObject[] _platforms; // ������ �÷��� �迭�� ����
    private int _nextSpawnPlatformIndex = 0; // ����� ���� ����

    public Vector2 prevCheckPoint;
    public Vector2 currentCheckPoint;

    // ���� ���� ��ġ
    private readonly Vector2 _poolPosition;

    private void Start()
    {
        _poolPosition.Set(0f, -50f);
        _platforms = new GameObject[MaxPlatformCnt];
        for(int i = 0; i < MaxPlatformCnt; i++)
        {
            _poolPosition.Set(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            _platforms[i] = Instantiate(PlatformPrefab, _poolPosition, Quaternion.identity); // ������ �÷��� �迭�� �־��
            _platforms[i].SetActive(true);
        }
    }

    private void Update()
    {
        // �������ư��� ���ǹ�ġ
        // üũ����Ʈ ��ġ ���� +xPos ��ŭ�� �÷��� ������ġ�� �Ѵ�
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
