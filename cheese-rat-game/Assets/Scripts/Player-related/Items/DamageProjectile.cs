using UnityEngine;

public class DamageProjectile : ProjectileBase
{
    [SerializeField] protected float _minimumDamage;
    [SerializeField] protected float _maximumDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        float attackDamage = GenerateRandomDamage();

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthLogic>().TakeDamage(attackDamage);
        }
        Destroy(gameObject);
    }

    private float GenerateRandomDamage()
    {
        return Random.Range(_minimumDamage, _maximumDamage);
    }
}
