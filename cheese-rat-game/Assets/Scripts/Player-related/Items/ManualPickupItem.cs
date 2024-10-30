using System;
using UnityEngine;

public abstract class ManualPickupItem : MonoBehaviour
{

    //gameobject reference to the player that owns this pick-up item
    protected GameObject _playerObject = null;
    protected PlayerMovement _playerMovement = null;
    protected HealthLogic _playerHealth = null;
    protected bool collidingWithPlayer = false;
    [SerializeField] protected Collider2D _collider;
    [SerializeField] protected SpriteRenderer _sprite ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _collider.enabled = true;
        _sprite.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collidingWithPlayer = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collidingWithPlayer = false;
        }
    }

    public bool SetPlayerObject(GameObject playerObject)
    {
        if (playerObject)
        {
            if (_playerObject == null) { 
                _playerObject = playerObject; 
                return true; 
            }
            else { 
                Debug.Log("Cannot set player object reference until it is set to null"); 
                return false; 
            }
        } else
        {
            return false;
        }
    }

    public bool SetPlayerMovementRef(PlayerMovement playerMovement)
    {
        if (playerMovement)
        {
            if (_playerMovement == null) { 
                _playerMovement = playerMovement; 
                return true; 
            }
            else { 
                /*Debug.Log("Cannot set player movement reference until it is set to null");*/ 
                return false; 
            }
        } else
        {
            return false;
        }
    }

    public bool SetPlayerHealth(HealthLogic healthLogic)
    {
        if (healthLogic)
        {
            if (_playerHealth == null) { 
                _playerHealth = healthLogic; 
                return true; 
            }
            else { 
                /*Debug.Log("Cannot set player health reference until it is set to null"); */
                return false; 
            }
        } else
        {
            return false;
        }
    }

    public abstract void UseItem();

    public void HideItem()
    {
        _collider.enabled = false;
        _sprite.enabled = false;
    }

    public void ShowItem()
    {
        _collider.enabled = true;
        _sprite.enabled = true;
    }

    protected bool IsUsable()
    {
        return _playerHealth != null && _playerMovement != null && _playerObject != null ;
    }

}
