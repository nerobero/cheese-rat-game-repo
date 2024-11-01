using UnityEngine;
using FMODUnity;

public class Cheese : MonoBehaviour
{
    public GameObject cheeseObject;
    public GameObject playerObject;
    public bool collidingWithPlayer = false;

    public float speed = 20f;
    private Vector2 randomDirection;
    private float moveDuration = 5f;
    private float timer = 0f;
    public Rigidbody2D myRigidBody2D;
    [SerializeField] protected Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collidingWithPlayer = true;
            playerObject = collision.gameObject;
        }

        if (collision.CompareTag("Wall"))
        {
            randomDirection = -randomDirection;
            timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collidingWithPlayer = false;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerObject.GetComponent<PlayerMovement>().carryingCheese)
        {
            animator.SetBool("isWalking", false);
        } else {
            animator.SetBool("isWalking", true);
        }

        if (playerObject != null && playerObject.GetComponent<PlayerMovement>().carryingCheese)
        {
            cheeseObject.transform.position = playerObject.transform.position;
         /* FMOD.Studio.EventInstance PickupSound;
            PickupSound = RuntimeManager.CreateInstance ("event:/Oneshots/ping2");
            PickupSound.start(); */
            RuntimeManager.PlayOneShot("event:/Oneshots/ping2");   /* This my Bookgang ah code ~Shiori */
        } else {
            if (timer < moveDuration)
            {
                myRigidBody2D.MovePosition(myRigidBody2D.position + randomDirection * speed * Time.deltaTime);
                timer += Time.deltaTime;
                
            } else {
                // Stop movement after the duration
                timer = 0f;
                randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            }
        }
    }
}