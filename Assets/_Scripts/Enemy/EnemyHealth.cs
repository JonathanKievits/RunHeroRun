using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int _maxHealth, _currentHealth;

    [SerializeField] private EnemyHealthBar _healthBar;

    private void Start()
    {
        _maxHealth = 500;
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoDamage(25);
        }
    }
    
    public void DoDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
        if(_currentHealth <= 0)
        {
            //Plays a sound when the enemy has no HP left and destroys the enemy
            FindObjectOfType<PlayerAudio>().PlaySound("DeadEnemy");
            Destroy(this.gameObject);
        }
        else
        {
            FindObjectOfType<PlayerAudio>().PlaySound("HitEnemy");
        }
    }
}
