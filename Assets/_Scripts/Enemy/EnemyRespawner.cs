using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRespawner : MonoBehaviour
{
    private IEnumerator _coroutine;
    private GameObject _enemy = null;
    private int timing = 5;
    [SerializeField] private Text _respawnText = null;
    [SerializeField] private EnemyHealth _eHealth = null;

    private void Awake()
    {
        _enemy = GameObject.Find("Enemy");
    }

    private void Start()
    {
        _respawnText.enabled = false;
    }

    public void RespawnEnemy()
    {
        _coroutine = Countdown(timing);
        StartCoroutine(_coroutine);
        _enemy.SetActive(false);
        _respawnText.enabled = true;
    }

    private IEnumerator Countdown(int respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        //spawn the enemy
        _enemy.SetActive(true);
        _respawnText.enabled = false;
        _eHealth.ResetHealth();
        Debug.Log("Respawned");
    }
}
