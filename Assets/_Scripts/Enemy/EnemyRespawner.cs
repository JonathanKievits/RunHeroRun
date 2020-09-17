using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyRespawner : MonoBehaviour
{
    private IEnumerator _coroutine;
    private GameObject _enemy = null;
    private int timing = 5;
    [SerializeField] private Text _respawnText = null;

    public UnityEvent OnRespawn;

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
        FindObjectOfType<PlayerAudio>().PlaySound("DeadEnemy");
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
        OnRespawn.Invoke();
    }
}
