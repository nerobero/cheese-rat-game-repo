using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public bool carryingCheese = false;
    public Rigidbody2D myRigidBody2D;
    public float moveSpeed = 10;
    private Vector2 movement;
    public GameObject cheeseObject; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        if (Input.GetKey(KeyCode.E) && cheeseObject.GetComponent<Cheese>().collidingWithPlayer) // Pick Up Cheese
            {
                carryingCheese = true;
            }
        myRigidBody2D.linearVelocity = moveSpeed * movement;
    }   
}