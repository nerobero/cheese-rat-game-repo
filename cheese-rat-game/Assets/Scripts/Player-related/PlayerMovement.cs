using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool carryingCheese = false;
    public Rigidbody2D myRigidBody2D;
    public float moveSpeed = 10;
    private Vector2 movement;
    public GameObject cheeseObject;

    private ManualPickupItem _currentUsableItem;
    private GameObject _currentInteractable;
    private bool _isInteractable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentInteractable = null;
        _currentUsableItem = null;
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKey(KeyCode.E)) // Pick Up Cheese
            {
                if (cheeseObject.GetComponent<Cheese>().collidingWithPlayer)
                {
                    carryingCheese = true;
                }

                if (_currentInteractable && _isInteractable)
                {
                    SetCurrentItem(_currentInteractable);
                }
            }
        if (Input.GetKey(KeyCode.F) && _currentUsableItem != null)
        {
            _currentUsableItem.UseItem();
            Destroy(_currentUsableItem);
        }
        myRigidBody2D.linearVelocity = moveSpeed * movement;
    }

    public void SetCurrentItem(GameObject currentItem) { 
        if (currentItem)
        {
            _currentUsableItem = (ManualPickupItem)currentItem;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _currentInteractable = collision.gameObject;
            _isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _currentInteractable = null;
            _isInteractable = false;
        }
    }
}