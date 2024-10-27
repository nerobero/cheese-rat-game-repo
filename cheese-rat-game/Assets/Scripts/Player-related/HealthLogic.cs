using UnityEngine;

public class HealthLogic : MonoBehaviour
{
    [SerializeField] private float _maximumHealth;
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float healAmount)
    {
        _currentHealth += healAmount;
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth <= 0f)
        {
            _isDead = true;
        } else
        {
            _currentHealth -= damageAmount;
        }
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
}
