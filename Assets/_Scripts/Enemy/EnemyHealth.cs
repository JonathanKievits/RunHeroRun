using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int  _currentHealth, _maxHealth;
    [SerializeField] private EnemyHealthBar _healthBar = null;
    [SerializeField] private EnemyRespawner _eSpawner = null;

    private void Awake()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }
    
    /*
        When this function is called it ask first for a damage number so it can deduct the damage amount from the current health from the enemy.
        After that it sets the slider which in this case is used as a healthbar visual indicator. 
        Next it checks if the hp is 0 or below 0 so it can call the next function or else it plays a sound of the enemy getting hit + the animation.
      */
    public void DoDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
        if(_currentHealth <= 0)
        {
            _eSpawner.RespawnEnemy();
        }
        else
        {
            FindObjectOfType<PlayerAudio>().PlaySound("HitEnemy");
            FindObjectOfType<CallAnimations>().EnemyAnimaton("RecievedDamage", true);
        }
    }

    //This function is called when the enemy respawns so it has the correct amount of health again 
    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetHealth(_currentHealth);
    }

    public void StopAnim()
    {
        FindObjectOfType<CallAnimations>().EnemyAnimaton("RecievedDamage", false);
    }
}
