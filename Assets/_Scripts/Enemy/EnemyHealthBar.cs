using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider = null;
    private int _currentHealth;

    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
        _currentHealth = health;
    }

    public void SetHealth(int damage)
    {
        _currentHealth -= damage;
        _slider.value = _currentHealth;
        FindObjectOfType<PlayerAudio>().PlaySound("HealthPing");
    }
}
