using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private static readonly float MIN_NOMAL_Y = Mathf.Sin(45f * Mathf.Deg2Rad);

    private void Awake()
    {
        GameManager.Instance._isEnd = false;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint point = collision.GetContact(0);
        if (point.normal.y >= MIN_NOMAL_Y)
        {
            _playerMovement._isOnGround = true;
            _playerMovement._jumpCount = 0;
        }

        // ÇÃ·§Æû¿¡ »¡¸® ¶³¾îÁö°Å³ª, Àß¸øµÈ°÷¿¡ ÂøÁöÇÏ¸é Á×À½
        if((collision.gameObject.CompareTag("SafeZone") && (GameManager.Instance.fallingSpeed >= GameManager.Instance.DieSpeed)) || collision.gameObject.CompareTag("DeadZone"))
        {
            Die();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        // ÇÃ·§Æû¿¡ ÂøÁöÇÑÈÄ Á¡ÇÁ ´©¸£¸é ±× À§Ä¡ ÀúÀå
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
