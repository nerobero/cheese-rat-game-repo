using UnityEngine;

public class Spider_Test_Movement : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    private float moveSpeed = 10f;

    public Animator myAnimator;

    protected Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        movement = new Vector2Int(0, 0);
    

        if (Input.GetKey(KeyCode.T)) // Move Up
            {
                movement.y += 1;
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
            }
        if (Input.GetKey(KeyCode.G)) // Move Down
            {
                movement.y += -1;
                transform.localScale = new Vector3(0.4f, -0.4f, 1);
            }
        if (Input.GetKey(KeyCode.F)) // Move Left
            {
                movement.x += -1;
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
            }
        if (Input.GetKey(KeyCode.H)) // Move Right
        ///////////HEYYYYYYYYYYYYYYYYYYYY - For the weird flipping - adjust the pivot in the sliced sprites is all. Not doing it now cuz this is just a test
            {
                movement.x += 1;
                transform.localScale = new Vector3(-0.4f, 0.4f, 1);
            }

        myAnimator.SetFloat("Horizontal", Mathf.Abs(movement.x));
        myAnimator.SetFloat("Vertical", Mathf.Abs(movement.y));
        if (Mathf.Abs(movement.x) == 1 && Mathf.Abs(movement.y) == 0)
        {
            myAnimator.SetBool("AxisChangeToY", false);
            myAnimator.SetBool("AxisChangeToX", true);
        }
        if (Mathf.Abs(movement.x) == 0 && Mathf.Abs(movement.y) == 1)
        {
            myAnimator.SetBool("AxisChangeToX", false);
            myAnimator.SetBool("AxisChangeToY", true);
        }
        myRigidBody2D.linearVelocity = moveSpeed * movement;
    }

}
