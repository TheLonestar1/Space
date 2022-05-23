using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour, IDamageable
{
    
    [SerializeField, Range(100, 1000)]
    private int _maxHealth = 200;
    private int _currentHealth;
    [SerializeField]
    private UnityEvent OnEndedHealth;
    protected virtual void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    protected int GetCurrentHealth()
    {
        return _currentHealth;
    }
    
    public virtual void TakeDamage(int value)
    {
        _currentHealth -= value;

        if(_currentHealth <= 0)
            OnEndedHealth.Invoke();
    }
    public virtual void AddHealth(int value)
    {
       
        if (value > 0)
        {
            _currentHealth += value;
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
        }
    }
}
