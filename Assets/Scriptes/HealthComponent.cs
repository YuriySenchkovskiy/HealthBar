using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _minHealth;
    private int _maxHealth;

    public UnityAction<int> OnChangedHealth;
    public int Health => _health;
    
    private void Start()
    {
        _maxHealth = _health;
        _minHealth = 0;
    }
        
    public void ApplyHeal(int heal)
    {
        _health = Mathf.Clamp(_health + heal, _minHealth, _maxHealth);
        OnChangedHealth?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        OnChangedHealth?.Invoke(_health);
    }
}