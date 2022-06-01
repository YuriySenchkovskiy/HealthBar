using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthComponent _health;
    [SerializeField] private float _speed;
    [SerializeField] private Image _bar;

    private Coroutine _currentCoroutine;
    private float _previousHp;
    private int _maxHealth;

    private void OnEnable()
    { 
        _health.ChangedHealth += OnSetBarValue;
    }

    private void Start()
    {
        _maxHealth = _health.Health;
        _previousHp = _maxHealth;
    }

    private void OnDisable()
    { 
        _health.ChangedHealth -= OnSetBarValue;
    }

    private void OnSetBarValue(int health)
    { 
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
            
        _currentCoroutine = StartCoroutine(ChangeBarValue(health));
    }

    private IEnumerator ChangeBarValue(int health)
    {
        while (_previousHp != health)
        {
            _previousHp = Mathf.MoveTowards(_previousHp, health, Time.deltaTime * _speed);
            SetProgress(_previousHp / _maxHealth);
                
            yield return null;
        }
    }
        
    private void SetProgress(float progress)
    {
        _bar.fillAmount = progress;
    }
}