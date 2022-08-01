using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private FuelSystem _fule;

    private static readonly float MIN_NOMAL_Y = Mathf.Sin(45f * Mathf.Deg2Rad);

    private void Awake()
    {
        GameManager.Instance._isEnd = false;
        _playerMovement = GetComponent<PlayerMovement>();
        _fule = GetComponent<FuelSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint point = collision.GetContact(0);
        if (point.normal.y >= MIN_NOMAL_Y)
        {
            _playerMovement._isOnGround = true;
            _playerMovement._jumpCount = 0;
        }

        // �÷����� ���� �������ų�, �߸��Ȱ��� �����ϸ� ����
        if((collision.gameObject.CompareTag("SafeZone") && (GameManager.Instance.fallingSpeed >= GameManager.Instance.DieSpeed)) || collision.gameObject.CompareTag("DeadZone"))
        {
            Die();
        }

        // �÷��� ������ ����ä��
        if(collision.gameObject.CompareTag("SafeZone"))
        {
            _fule.CurrentFuel = 100f;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        // �÷����� �������� ���� ������ �� ��ġ ����
        if(collision.gameObject.CompareTag("SafeZone"))
        {
            GameManager.Instance.LastCheckPoint = transform.position;
        }
        
    }

    public void Die()
    {
        GameManager.Instance._isEnd = true;
        Destroy(gameObject);
    }
}
