using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private FuelSystem _fule;
    
    private static readonly float MIN_NOMAL_Y = Mathf.Sin(45f * Mathf.Deg2Rad);

    public GameObject Astronaut;
    public GameObject Explosion;

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

        // ÇÃ·§Æû¿¡ »¡¸® ¶³¾îÁö°Å³ª, Àß¸øµÈ°÷¿¡ ÂøÁöÇÏ¸é Á×À½
        if((collision.gameObject.CompareTag("SafeZone") && (GameManager.Instance.fallingSpeed >= GameManager.Instance.DieSpeed)) || collision.gameObject.CompareTag("DeadZone"))
        {
            Die();
        }

        // ÇÃ·§Æû ¾ÈÂø½Ã ¿¬·áÃ¤¿ò
        if(collision.gameObject.CompareTag("SafeZone"))
        {
            _fule.CurrentFuel = 100f;
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
        Astronaut.SetActive(false);
        GameObject particleObj = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(particleObj, 2f);

        Invoke("OnGameEnd", 0.8f);
    }

    public void OnGameEnd()
    {
        GameManager.Instance._isEnd = true;
        Destroy(gameObject);

    }
}
