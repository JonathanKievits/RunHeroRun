using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public class EnemyHealth : MonoBehaviour
{
    private int  _currentHealth, _maxHealth;
    private bool _isDead;

    public UnityEvent OnDeath; 
    public MyIntEvent OnHealthChange, OnSetMaxHealth;

    private void Awake()
    {
        _isDead = false;
        _maxHealth = 100;
        OnSetMaxHealth.Invoke(_maxHealth);
        _currentHealth = _maxHealth;
    }

    /*
        When this function is called it ask first for a damage number so it can deduct the damage amount from the current health from the enemy.
        After that it sets the slider which in this case is used as a healthbar visual indicator. 
        Next it checks if the hp is 0 or below 0 so it can call the next function or else it plays a sound of the enemy getting hit + the animation.
      */
    public void DoDamage(int damage)
    {
        if (!_isDead)
        {
            _currentHealth -= damage;
            OnHealthChange.Invoke(damage);
            if (_currentHealth <= 0)
            {
                _isDead = true;
                OnDeath.Invoke();
            }
            else
            {
                FindObjectOfType<PlayerAudio>().PlaySound("HitEnemy");
                FindObjectOfType<CallAnimations>().EnemyAnimaton("RecievedDamage", true);
            }
        }
    }

    //This function is called when the enemy respawns so it has the correct amount of health again 
    public void ResetHealth()
    {
        _isDead = false;
        _currentHealth = _maxHealth;
        OnSetMaxHealth.Invoke(_maxHealth);
    }

    public void StopAnim()
    {
        FindObjectOfType<CallAnimations>().EnemyAnimaton("RecievedDamage", false);
    }
}
