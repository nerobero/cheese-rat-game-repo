using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool carryingCheese = false;
    public Rigidbody2D myRigidBody2D;
    public float moveSpeed = 10f;
    protected Vector2 movement;
    protected GameObject cheeseObject = null;

    protected ManualPickupItem _currentUsableItem;
    protected GameObject _currentInteractable;
    protected bool _isInteractable = false;

    protected HealthLogic _playerHealth = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        _currentInteractable = null;
        _currentUsableItem = null;

        if (gameObject.GetComponent<HealthLogic>() != null)
        {
            _playerHealth = gameObject.GetComponent<HealthLogic>();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        movement = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) // Move Up
            {
                movement.y += 1;
            }
        if (Input.GetKey(KeyCode.S)) // Move Down
            {
                movement.y += -1;
            }
        if (Input.GetKey(KeyCode.A)) // Move Left
            {
                movement.x += -1;
            }
        if (Input.GetKey(KeyCode.D)) // Move Right
            {
                movement.x += 1;
            }
        if (Input.GetKey(KeyCode.Space)) // Drop Cheese
            {
                carryingCheese = false;
            }
        if (Input.GetKey(KeyCode.E)) 
        {
            if (cheeseObject != null && cheeseObject.GetComponent<Cheese>().collidingWithPlayer)
            {
                carryingCheese = true;
            }

            if (_currentInteractable && _isInteractable)
            {
                SetCurrentItem(_currentInteractable);
                bool _isValidUsableItem;
                _isValidUsableItem = false;
                _isValidUsableItem = _currentUsableItem.SetPlayerObject(gameObject);
                _isValidUsableItem = _isValidUsableItem && _currentUsableItem.SetPlayerMovementRef(this);
                _isValidUsableItem = _isValidUsableItem && _currentUsableItem.SetPlayerHealth(_playerHealth);

                if (!_isValidUsableItem)
                {
                    _currentUsableItem = null;
                    _currentUsableItem.ShowItem();
                }
            }
        }
        if (Input.GetKey(KeyCode.F) && _currentUsableItem != null)
        {
            _currentUsableItem.UseItem();
            _currentUsableItem = null;
        }
        myRigidBody2D.linearVelocity = moveSpeed * movement;
    }

    public void SetCurrentItem(GameObject currentItem) { 
        if (currentItem)
        {
            _currentUsableItem = currentItem.GetComponent<ManualPickupItem>();
            _currentUsableItem.HideItem();
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _currentInteractable = collision.gameObject;
            _isInteractable = true;
        }
        if (collision.gameObject.tag == "Cheese")
        {
            cheeseObject = collision.gameObject;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _currentInteractable = null;
            _isInteractable = false;
        }
        if (collision.gameObject.tag == "Cheese")
        {
            cheeseObject = null;
        }
    }
}