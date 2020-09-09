using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int _maxHealth, _currentHealth;

    [SerializeField] private EnemyHealthBar HealthBar;

    private void Start()
    {
        _maxHealth = 500;
        _currentHealth = _maxHealth;
        HealthBar.SetMaxHealth(_maxHealth);
    }

    public void DoDamage(int damage)
    {
        _currentHealth -= damage;
        HealthBar.SetHealth(_currentHealth);
    }
}