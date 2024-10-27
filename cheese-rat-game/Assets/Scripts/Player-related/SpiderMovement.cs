using UnityEngine;

public class SpiderMovement : PlayerMovement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    protected override void Update()
    {
        movement = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow)) // Move Up
        {
            movement.y += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Move Down
        {
            movement.y += -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Move Left
        {
            movement.x += -1;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Move Right
        {
            movement.x += 1;
        }
        if (Input.GetKey(KeyCode.KeypadEnter)) // Drop Cheese
        {
            carryingCheese = false;
        }
        if (Input.GetKey(KeyCode.RightShift)) // Pick Up Cheese
        {
            //if (cheeseObject.GetComponent<Cheese>().collidingWithPlayer)
            //{
            //    carryingCheese = true;
            //}

            if (_currentInteractable && _isInteractable)
            {
                SetCurrentItem(_currentInteractable);
                // sets the owner of the current usable item as  
                _currentUsableItem.SetPlayerObject(gameObject);
                _currentUsableItem.SetPlayerMovementRef(this);
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
