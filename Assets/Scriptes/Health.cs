using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthValue;

    private int _minHealth;
    private int _maxHealth;

    public UnityAction<int> ChangedHp;
    public int HealthValue => _healthValue;
    
    private void Start()
    {
        _maxHealth = _healthValue;
        _minHealth = 0;
    }
        
    public void ApplyHeal(int healthDelta)
    {
        _healthValue = Mathf.Clamp(_healthValue + healthDelta, _minHealth, _maxHealth);
        ChangedHp?.Invoke(_healthValue);
    }

    public void ApplyDamage(int damage)
    {
        _healthValue = Mathf.Clamp(_healthValue - damage, _minHealth, _maxHealth);
        ChangedHp?.Invoke(_healthValue);
    }
}