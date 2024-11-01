using System.Collections;
using UnityEngine;

public class PoisonProjectile : DamageProjectile
{
    // Slowing factor is always less than 1.0f;
    [SerializeField] private float _slowingFactor;
    private float _originalSpeed;
    private PlayerMovement movementComponent = null;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _collider.enabled = true;
        _sprite.enabled = true;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        float attackDamage = GenerateRandomDamage();

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthLogic>().TakeDamage(attackDamage);
            movementComponent = collision.gameObject.GetComponent<PlayerMovement>();
            if (movementComponent != null)
            {
                movementComponent.SetMovementSpeed(_originalSpeed * _slowingFactor);
                StartCoroutine(ResetSpeed(5f));
            }
            HideItem();
        }
        
    }

    private IEnumerator ResetSpeed(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("movement speed reset to original");
        movementComponent.SetMovementSpeed(_originalSpeed);
        movementComponent = null;
        Destroy(gameObject);
    }

    public void HideItem()
    {
        _collider.enabled = false;
        _sprite.enabled = false;
    }
}
