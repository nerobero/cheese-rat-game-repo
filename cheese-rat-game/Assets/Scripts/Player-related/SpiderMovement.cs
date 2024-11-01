using UnityEngine;
using UnityEngine.InputSystem;

public class SpiderMovement : PlayerMovement
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    protected override void Update()
    {
        movement = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow)) // Move Up
        {
            movement.y += 1;
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", movement.y);
            animator.SetFloat("LastInputX", 0);
            animator.SetFloat("LastInputY", movement.y);
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Move Down
        {
            movement.y += -1;
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", movement.y);
            animator.SetFloat("LastInputX", 0);
            animator.SetFloat("LastInputY", movement.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Move Left
        {
            movement.x += -1;
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", movement.x);
            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Move Right
        {
            movement.x += 1;
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", movement.x);
            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", 0);
        }
        if (movement == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.KeypadEnter)) // Drop Cheese
        {
            carryingCheese = false;
        }
        if (Input.GetKey(KeyCode.RightShift)) // Pick Up Cheese
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
        if (Input.GetKey(KeyCode.RightControl) && _currentUsableItem != null)
        {
            _currentUsableItem.UseItem();
            _currentUsableItem = null;
        }
        myRigidBody2D.linearVelocity = moveSpeed * movement;
    }
}
