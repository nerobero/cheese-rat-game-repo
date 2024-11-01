using Unity.VisualScripting;
using UnityEngine;

public class HealthLogic : MonoBehaviour
{
    [SerializeField] private float _maximumHealth;
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    private bool _isInvincible = false;
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

        if (_currentHealth >= _maximumHealth) { _currentHealth = _maximumHealth; }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth <= 0f)
        {
            _isDead = true;
            _currentHealth = 0f;
        }
        else
        {
           if (!_isInvincible && !_isDead)
            {
                _currentHealth -= damageAmount;
            }
        }
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetMaximumHealth()
    {
        return _maximumHealth;
    }

    public void SetToInvincible()
    {
        if (!_isDead)_isInvincible = true;
    }

    public void ResetInvincibility()
    {
        if (!_isDead) _isInvincible = false;
    }
}
